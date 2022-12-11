Set objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\cimv2")
Set oss = objWMIService.ExecQuery("Select Version from Win32_OperatingSystem where Primary=true")

If (oss.Count = 0) Then
    Wscript.Echo "Unable to get OS version"
    WScript.Quit 100
End If

For Each os in oss
    OSVersion = os.Version
    Exit For
Next

DotPos = InStr(OSVersion, ".")
DotPos2 = InStr(DotPos+1, OSVersion, ".")
If (DotPos2 = 0) Then
    DotPos2 = Len(OSVersion)+1
End If
OSVersionMaj = Mid(OSVersion, 1, DotPos-1)
OSVersionMin = Mid(OSVersion, DotPos+1, DotPos2-DotPos-1)
OSVersionMin = CDbl(OSVersionMin) / (10.0 ^ Len(OSVersionMin))
OSVersionNumber = CDbl(OSVersionMaj) + OSVersionMin

If (OSVersionNumber >= 6.0) Then
    ''' Rules for Vista/7/8
    
    Set WshShell = CreateObject("WScript.Shell") 
    WshShell.Run "netsh advfirewall firewall delete rule name=""LogMX"" direction=in", 0, true
    WshShell.Run "netsh advfirewall firewall delete rule name=""LogMX (64 bits)"" direction=in", 0, true
    WshShell.Run "netsh advfirewall firewall delete rule name=""LogMX"" direction=out", 0, true
    WshShell.Run "netsh advfirewall firewall delete rule name=""LogMX (64 bits)"" direction=out", 0, true
    
Else
 
    ''' Rules for Vista/7/8
    
    If WScript.Arguments.Count = 0 Then
        WScript.echo "Missing LogMX directory in argument."
        WScript.Quit 99
    End If
    
    LogMXDir = WScript.Arguments(0)
    LogMX32Exe = """" & LogMXDir & "\LogMX.exe"""
    LogMX64Exe = """" & LogMXDir & "\LogMX-64.exe"""
    
    Set WshShell = CreateObject("WScript.Shell") 
    WshShell.Run "netsh firewall delete allowedprogram profile=ALL program=" & LogMX32Exe, 0, true
    WshShell.Run "netsh firewall delete allowedprogram profile=ALL program=" & LogMX64Exe, 0, true

End If