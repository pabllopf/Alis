package sample.manager;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import javax.swing.Icon;

import com.lightysoft.logmx.business.LogURL;
import com.lightysoft.logmx.business.LogURLParameter;
import com.lightysoft.logmx.business.LogURLParameterType;
import com.lightysoft.logmx.mgr.AutoRefreshLineInfo;
import com.lightysoft.logmx.mgr.LogFileInfo;
import com.lightysoft.logmx.mgr.LogFileManager;
import com.lightysoft.logmx.mgr.ManagerSpecVersion;

/**
 * Sample Log file Manager handling HTTP protocol.
 * 
 * Please visit [https://logmx.com/manager-dev] to get more 
 * information on how to write Managers.
 * 
 * You can use LogMX API Javadoc located in the "help/api/" directory 
 * of your LogMX distribution.
 */
public class SampleHTTPManager extends LogFileManager {
    private String host = null;

    private String file = null;

    private int port = 0;

    private BufferedReader bufReader = null;

    private HttpURLConnection httpConnection = null;

    private String url = null;

    private long currFileDate = 0;

    private int currFileSize = 0;

    private static LogURL logURL = null;

    private static final String NAME = "Sample HTTP file manager";

    private static final String PROTOCOL = "http";

    private static final String URL_PARAM_HOST = "Host";

    private static final String URL_PARAM_PORT = "Port";

    private static final String URL_PARAM_FILE = "File";

    private static final int DEFAULT_PORT = 80;

    private static final String URL_PATTERN = PROTOCOL + "://{" + URL_PARAM_HOST + "}[:{"
            + URL_PARAM_PORT + "}][/{" + URL_PARAM_FILE + "}]";

    private static final Icon FILE_TYPE_ICON = getIconFile("gfx_http_file.png");

    private static final Icon FILE_TYPE_ICON_32 = getIconFile("gfx_http_file32.png");


    /**
     * Called by LogMX to get the name of this Manager.
     * This name can contain any character and is displayed in LogMX GUI.
     * 
     * @return 
     *      Manager name
     */
    @Override
    public String getName() {
        return NAME;
    }

    /**
     * Called by LogMX to get a template of <code>LogURL</code> used by this Manager.<BR/>
     * 
     * <BR/>
     * The returned <code>LogURL</code> can (should) be a static shared instance for better performance.
     * LogMX will not use it directly but will use a clone of it. 
     * 
     * @return 
     *      <code>LogURL</code> used by this Manager
     */
    @Override
    public LogURL getTemplateLogURL() {
        if (logURL == null) {
            logURL = new LogURL();
            logURL.addParameter(new LogURLParameter(URL_PARAM_HOST, LogURLParameterType.HOST));
            logURL.addParameter(new LogURLParameter(URL_PARAM_PORT, LogURLParameterType.INTEGER,
                DEFAULT_PORT, true));
            logURL.addParameter(new LogURLParameter(URL_PARAM_FILE, LogURLParameterType.FILEPATH,
                null, true)); // optional param to allow URLs like "http://logmx.com"
        }
        return logURL;
    }

    /**
     * Called by LogMX to know how to display a URL handled by this Manager.
     * The syntax is:
     * <UL>
     *   <LI><code>SimpleText</code> to denote text <code>"SimpleText"</code></LI>
     *   <LI><code>{MyParam}</code> to denote the value of {@link com.lightysoft.logmx.business.LogURLParameter} named <code>"MyParam"</code></LI>
     *   <LI><code>[SimpleOptionalPart]</code> to denote an optional part containing free text, <code>LogURLParameter</code> value, or both.</LI>
     * </UL>
     * <BR/>
     * Here are a few examples of patterns this method can return and URLs matching this pattern:<BR/>
     * <UL>
     *   <LI><code>scp://{Login}@{Host}:[{Port}:]{File}</code></LI>
     *      <UL>
     *         <LI><code>scp://john@myhost:22:/mydir/myfile.log</code></LI>
     *         <LI><code>scp://john@myhost:/myfile.log</code></LI>
     *      </UL>
     *   <LI><code>http://{Host}[:{Port}][/{File}]</code></LI>
     *      <UL>
     *         <LI><code>http://logmx.com:80/myscript.php?p=4</code></LI>
     *         <LI><code>http://logmx.com:80/mypage.html</code></LI>
     *         <LI><code>http://logmx.com</code></LI>
     *      </UL>
     * </UL>
     * 
     * @return 
     *      URL Pattern used by this Manager
     */
    @Override
    public String getURLPattern() {
        return URL_PATTERN;
    }

    /**
     * Called by LogMX to initialize the Manager for the specified resource.<BR/>
     * This method shouldn't try to open the resource yet, but should only save URL parameters 
     * for further use.
     * 
     * @param pLogURL
     *      LogURL for the resource this Manager will have to open
     * @param pURLString
     *      String representation for this URL (may be helpful for the Manager, especially to implement 
     *      {@link com.lightysoft.logmx.mgr.LogFileManager#getCurrentURL()}
     * @throws Exception
     *      If the Manager is not able to process this URL
     */
    @Override
    public void init(LogURL pLogURL, String pURLString) throws Exception {
        LogURLParameter hostParam = pLogURL.getParameter(URL_PARAM_HOST);
        LogURLParameter fileParam = pLogURL.getParameter(URL_PARAM_FILE);
        LogURLParameter portParam = pLogURL.getParameter(URL_PARAM_PORT);

        host = hostParam.getValue().toString();
        file = (fileParam.getValue() == null) ? "/" : fileParam.getValue().toString();
        port = (portParam.getValue() == null) ? DEFAULT_PORT : (Integer) portParam.getValue();
        url = pURLString;

        // If file path is not empty but doesn't start with "/", add this slash
        if (!file.equals("") && !file.startsWith("/")) {
            file = "/" + file;
        }
    }

    /**
     * Open the resource specified by {@link com.lightysoft.logmx.mgr.LogFileManager#init(LogURL, String)} to get ready 
     * to read, and return information on this resource (file size and date).<BR/>
     * If the Manager is not able to get the number of bytes to read, it can return a negative number.
     * As this number is used to display a progress bar while the Manager is loading the resource, returning a
     * negative number will make the progress bar stays at "100%" all the time.
     *  
     * @return
     *          File information structure (containing file size/date).
     * @throws Exception
     *      If the resource couldn't be opened (this Exception message will be displayed in LogMX GUI)
     */
    @Override
    public LogFileInfo prepareForReading() throws Exception {
        // Initialize HTTP connection
        URL url = new URL(PROTOCOL, host, port, file);
        httpConnection = (HttpURLConnection) url.openConnection();

        // Getting file size/date from HTTP headers
        currFileSize = httpConnection.getContentLength();
        currFileDate = httpConnection.getLastModified();

        // Getting an InputStream to read from
        InputStream inputStream = url.openStream();

        // Use a ZIP/GZIP/BZ2/... stream if needed
        inputStream = getDecompressedStream(file, inputStream);

        // Creating a buffered reader for this stream, using the Encoding specified by LogMX
        bufReader = new BufferedReader(new InputStreamReader(inputStream, getEncoding()));

        return new LogFileInfo(currFileSize, currFileDate);
    }

    /**
     * Called by LogMX to get the next line of text from the underlying Manager resource (file, stream, socket,...).<BR/>
     * Manager must return <B><code>null</code></B> if there is no more byte to read.
     * 
     * @return
     *      Next line, or <B><code>null</code></B> if there is no more byte to read.
     * @throws Exception
     *      If an error occurred while reading bytes. Managers should not handle Exceptions but should
     *      throw them instead, so that LogMX can catch them.
     */
    @Override
    public String readLine() throws Exception {
        return bufReader.readLine();
    }

    /**
     * Called by LogMX to get the current opened URL, matching this Manager URL template.<BR/>
     * This method may return the URL string received by {@link com.lightysoft.logmx.mgr.LogFileManager#init(LogURL, String)}, 
     * or use {@link com.lightysoft.logmx.mgr.LogFileManager#getURLFromLogURL(LogURL, String)} to construct the URL. 
     * 
     * @return
     *      Current opened URL
     */
    @Override
    public String getCurrentURL() {
        return url;
    }

    /**
     * Called by LogMX to know when the opened resource was modified for the last time.<BR/>
     * The expected result is a standard Java timestamp (number of milliseconds since 01/01/1970, 00:00:00 GMT). 
     * For example, if you have a Java Date, you can get such a timestamp using {@link java.util.Date#getTime()}.<BR/>
     * <BR/>
     * <B>This method may be called periodically, so it should be rather fast (e.g. no socket connection, but fast I/O operations).</B><BR/>
     * <BR/>
     * If the Manager is not able to get this timestamp, it may return 0, but file-change detection will be affected.
     *  
     * @return
     *      A Java-based timestamp of last modification, or 0 if Manager can't get this timestamp
     */
    @Override
    public long getCurrentFileLastModifDate() {
        return currFileDate;
    }

    /**
     * Called by LogMX to get the current resource size in bytes.<BR/>
     * <BR/>
     * <B>This method may be called periodically, so it should be rather fast (e.g. no socket connection, but fast I/O operations).</B><BR/>
     * <BR/>
     * If the Manager is not able to get this timestamp, it may return -1, but file-change detection will be affected.
     *  
     * @return
     *      Current resource size in bytes, or -1 if Manager can't get this size
     */
    @Override
    public long getCurrentFileSize() {
        return currFileSize;
    }

    /**
     * Called by LogMX to get this Manager icon, which must be a 16x16 icon.<BR/> 
     * Manager may use {@link com.lightysoft.logmx.mgr.LogFileManager#getIconFile(String)} to get an icon file
     * contained in LogMX pictures directory, in order to avoid relative file path issues.<BR/> 
     * This icon may (should) be cached, the same instance may be returned for each call for better performances.<BR/>
     * If <code>null</code> is returned, a default icon will be used.
     *  
     * @return
     *      Manager icon, or <code>null</code> to use a default icon.
     */
    @Override
    public Icon getFileTypeIcon() {
        return FILE_TYPE_ICON;
    }

    @Override
    public Icon getFileTypeIcon32x32() {
        return FILE_TYPE_ICON_32;
    }

    /**
     * Called by LogMX to get the Protocol handled by this Manager.<BR>
     * This protocol can be any string, like "http", "jdbc", "ftp", "myprotocol", ...<BR>
     * LogMX will use it to find the Manager to use for a given a URL (eg: "jdbc:oracle:thin:@host:1521:db") 
     * 
     * @return
     *      Protocol handled by this Manager
     */
    @Override
    public String getProtocolName() {
        return PROTOCOL;
    }

    /**
     * Called by LogMX when it doesn't need to use this Manager anymore.<BR/>
     * This method should release all resources allocated by this Manager (e.g. close file, socket,...)<BR/>
     * Once this method is called, LogMX will not call <code>readLine()</code>.<BR/>
     */
    @Override
    public void releaseResources(boolean pSoftRelease) {
        if (bufReader != null) {
            try {
                bufReader.close();
            } catch (IOException e) {
                // doesn't mind
                e.printStackTrace();
            }
        }
        if (httpConnection != null) {
            httpConnection.disconnect();
        }
    }

    /**
     * Called by LogMX to get the Manager Specification version supported by this Manager.
     * For example, this method can return <code>ManagerSpecVersion.V1_2</code>
     *   
     * @return
     *      Supported Manager Specification version
     */
    @Override
    public ManagerSpecVersion getSpecificationVersion() {
        return ManagerSpecVersion.V1_2;
    }

    /**
     * Called by LogMX to know if this Manger can delete (i.e. remove from disk) the current file.<BR/>
     * If <code>false</code> is returned, LogMX will not call {@link com.lightysoft.logmx.mgr.LogFileManager#deleteFile()}
     * 
     * @return
     *      <code>true</code> if this Manager can delete the current file, or <code>false</code> if it can't.
     */
    @Override
    public boolean supportFileDelete() {
        return false;
    }

    /**
     * Called by LogMX to know if this Manger can flush (i.e. empty) the current file.<BR/>
     * If <code>false</code> is returned, LogMX will not call {@link com.lightysoft.logmx.mgr.LogFileManager#flushFile()}
     * 
     * @return
     *      <code>true</code> if this Manager can flush the current file, or <code>false</code> if it can't.
     */
    @Override
    public boolean supportFileFlush() {
        return false;
    }

    /**
     * Called by LogMX to know if this Manager support header reading (read a specified number of bytes from the beginning of the file).<BR/>
     * Used for Auto Refresh and Auto detect encoding features.
     * If <code>false</code> is returned, LogMX will not call {@link com.lightysoft.logmx.mgr.LogFileManager#readFileHeader(int)}
     * 
     * @return
     *      <code>true</code> if this Manager support header reading, or <code>false</code> if it doesn't.
     */
    @Override
    public boolean supportHeaderReading() {
        return false;
    }

    /**
     * Called by LogMX to know if this Manager support random access (read bytes starting at a specified offset).<BR/>
     * Used for Auto Refresh feature only.
     * If <code>false</code> is returned, LogMX will not call {@link com.lightysoft.logmx.mgr.LogFileManager#readLineAtOffset(long)}
     * 
     * @return
     *      <code>true</code> if this Manager support random access, or <code>false</code> if it doesn't.
     */
    @Override
    public boolean supportRandomAccess() {
        return false;
    }

    /**
     * Called by LogMX to delete (i.e. remove from disk) the current file.<BR/>
     * If this Manager doesn't support this feature ({@link com.lightysoft.logmx.mgr.LogFileManager#supportFileDelete()} 
     * returns <code>false</code>), this method may only contain "<code>return false;</code>".
     * 
     * @return
     *      <code>true</code> if deletion succeeded, or <code>false</code> it didn't.
     */
    @Override
    public boolean deleteFile() {
        // Unsupported operation
        return false;
    }

    /**
     * Called by LogMX to flush (i.e. empty) the current file.<BR/>
     * If this Manager doesn't support this feature ({@link com.lightysoft.logmx.mgr.LogFileManager#supportFileFlush()} 
     * returns <code>false</code>), this method may only contain "<code>return false;</code>".
     * 
     * @return
     *      <code>true</code> if flush succeeded, or <code>false</code> it didn't.
     */
    @Override
    public boolean flushFile() {
        // Unsupported operation
        return false;
    }

    /**
     * Called by LogMX to read the first <code>pNbBytes</code> bytes from the underlying file or resource.<BR/>
     * Only Managers supporting Auto Refresh must implement this method, others should return <code>null</code>.
     *  
     * @param pNbBytes
     *      Number of bytes to read. <B>If negative, Manager must read as much bytes as possible</B>
     *      (for example, up to the end of file)
     * @return 
     *      Read bytes, or <code>null</code> if Manager doesn't support header reading
     * @throws Exception
     *      If Manager could not read bytes
     */
    @Override
    public byte[] readFileHeader(int pNbBytes) throws Exception {
        // Unsupported operation
        return null;
    }

    /**
     * Called by LogMX to read the line of text starting at the specified offset.<BR/>
     * Only Managers supporting Auto Refresh must implement this method, others should return <code>null</code>.
     * 
     * @param pOffset
     *      Starting offset
     * @return
     *      Information on read line (text and EOF flag), or <code>null</code> if Manager doesn't support header reading
     * @throws Exception
     *      If Manager could not read bytes
     */
    @Override
    public AutoRefreshLineInfo readLineAtOffset(long pOffset) throws Exception {
        // Unsupported operation
        return null;
    }

    /**
     * Called by LogMX to know the current position in file.<BR/>
     * Only Managers supporting Auto Refresh must implement this method, others should return 0.
     * 
     * @return
     *      Current offset in file
     */
    @Override
    public long getCurrentOffset() {
        // Unsupported operation
        return 0;
    }

}
