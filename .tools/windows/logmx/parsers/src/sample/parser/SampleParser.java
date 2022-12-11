package sample.parser;

import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import com.lightysoft.logmx.business.ParsedEntry;
import com.lightysoft.logmx.mgr.LogFileParser;

/**
 * Sample LogMX Parser able to parse a log file with multi-line support and Relative Date support.<BR/>
 * Here is an example of log file suitable for this parser:<BR/>
 * <PRE>
 * 
 *   07/03/2007, 16:51:00 (T0+1834ms) | ERROR | com.company.soft.DatabaseManager | A simple text on a single line 
 *   07/03/2007, 16:51:01 (T0+2805ms) | INFO | com.company.soft.gui.MainFrame | A simple text on 
 *   two lines 
 *   07/03/2007, 16:51:02 (T0+3810ms) | WARNING | com.company.soft.gui.MainFrame | A simple text on a single line
 *   
 * </PRE>
 */
public class SampleParser extends LogFileParser {
    /** Current parsed log entry */
    private ParsedEntry entry = null;

    /** Entry date format */
    private SimpleDateFormat dateFormat = null;

    /** Mutex to avoid that multiple threads use the same Date formatter at the same time */
    private final Object DATE_FORMATTER_MUTEX = new Object();

    /** Pattern for entry begin */
    private final static Pattern ENTRY_BEGIN_PATTERN = Pattern
        .compile("^\\d{2}/\\d{2}/\\d{4}, \\d{2}:\\d{2}:\\d{2} \\(T0\\+(\\d+)ms\\).*$");

    /** Buffer for Entry message (improves performance for multi-lines entries)  */
    private StringBuilder entryMsgBuffer = null;

    /** Key of user-defined field "timestamp" */
    private static final String EXTRA_TIMESTAMP_FIELD_KEY = "Timestamp";

    /** User-defined fields names (here, only one) */
    private static final List<String> EXTRA_FIELDS_KEYS = Arrays
        .asList(EXTRA_TIMESTAMP_FIELD_KEY);


    /** 
     * Returns the name of this parser
     * @see com.lightysoft.logmx.mgr.LogFileParser#getParserName()
     */
    @Override
    public String getParserName() {
        return "Sample Parser";
    }

    /**
     * Returns the supported file type for this parser
     * @see com.lightysoft.logmx.mgr.LogFileParser#getSupportedFileType()
     */
    @Override
    public String getSupportedFileType() {
        return "LogMX sample log files";
    }

    /**
     * Process the new line of text read from file 
     * @see com.lightysoft.logmx.mgr.LogFileParser#parseLine(java.lang.String)
     */
    @Override
    protected void parseLine(String line) throws Exception {
        // If end of file, records last entry if necessary, and exits
        if (line == null) {
            recordPreviousEntryIfExists();
            return;
        }

        Matcher matcher = ENTRY_BEGIN_PATTERN.matcher(line);
        if (matcher.matches()) {
            // Record previous found entry if exists, then create a new one
            prepareNewEntry();

            String[] fields = line.split("\\|");

            entry.setDate(fields[0].trim());
            entry.setLevel(fields[1].trim());
            entry.setEmitter(fields[2].trim());
            entryMsgBuffer.append(fields[3].trim());
            entry.getUserDefinedFields().put(EXTRA_TIMESTAMP_FIELD_KEY, matcher.group(1)); // save entry timestamp (ex: T0+1546ms)
        } else if (entry != null) {
            entryMsgBuffer.append('\n').append(line); // appends this line to previous entry's text
        }
    }

    /** 
     * Returns the ordered list of user-defined fields to display (given by their key), for each entry.
     * @see com.lightysoft.logmx.mgr.LogFileParser#getUserDefinedFields()
     */
    @Override
    public List<String> getUserDefinedFields() {
        return EXTRA_FIELDS_KEYS;
    }

    /**
     * Returns a relative Date for the given entry (if entry's ExtraInfo contains "1265", 
     * it means "T0 + 1265 ms", so simply return "new Date(1265)")
     * @see com.lightysoft.logmx.mgr.LogFileParser#getRelativeEntryDate(com.lightysoft.logmx.business.ParsedEntry)
     */
    @Override
    public Date getRelativeEntryDate(ParsedEntry pEntry) throws Exception {
        final String strTimeStamp = pEntry.getUserDefinedFields().get(EXTRA_TIMESTAMP_FIELD_KEY)
            .toString();
        return new Date(Integer.parseInt(strTimeStamp));
    }

    /**
     * Returns the absolute Date for the given entry 
     * @see com.lightysoft.logmx.mgr.LogFileParser#getAbsoluteEntryDate(com.lightysoft.logmx.business.ParsedEntry)
     */
    @Override
    public Date getAbsoluteEntryDate(ParsedEntry pEntry) throws Exception {
        if (dateFormat == null) {
            // Now create the date formatter using the right Locale
            // (method "getLocale()" can't be called from the constructor) 
            dateFormat = new SimpleDateFormat("dd/MM/yyyy, HH:mm:ss", getLocale());
        }
        synchronized (DATE_FORMATTER_MUTEX) { // Java date formatter is not thread-safe
            return dateFormat.parse(pEntry.getDate()); // (the right-part "T0+..." will be ignored by the formatter)
        }
    }

    /**
     * Send to LogMX the current parsed log entry
     * @throws Exception
     */
    private void recordPreviousEntryIfExists() throws Exception {
        if (entry != null) {
            entry.setMessage(entryMsgBuffer.toString());
            addEntry(entry);
        }
    }

    /**
     * Send to LogMX the current parsed log entry, then create a new one
     * @throws Exception
     */
    private void prepareNewEntry() throws Exception {
        recordPreviousEntryIfExists();
        entry = createNewEntry();
        entryMsgBuffer = new StringBuilder(80);
        entry.setUserDefinedFields(new HashMap<String, Object>(1)); // Create an empty Map with only one element allocated
    }
}
