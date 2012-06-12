<%SendURL = "http://www.winsms.co.za/api/batchmessage.asp?user=MyLoginName&password=MyPassword&message=" & Request("Message")

' The following If - Then Statements can be replaced with a database lookup to determine the recipients Cell No based on Unique Identifier

' Note that the cell numbers must be in International format, i.e. 2783 as opposed to 083

If Request("Recipient") = "1" then
  CellNo = "27831111111;" 
end if 
If Request("Recipient") = "2" then
  CellNo = "27822222222;" 
end if 
If Request("Recipient") = "3" then
  CellNo = "27831111111;27822222222;" 
end if 

' Note the Trailing ";" semi-colon at the end of the cell number. This is essential.
' A single selection by the user eg "Marketing Manager" could result in multiple SMS's being send, eg Marketing Manager and Sales ' Consultant - Note the last If - Then Statement 


SendURL = SendURL & "&Numbers=" & CellNo

' We use an XMLObject - easisest way to get response from another .asp page - don't be thrown by the fact that it is an XML object not
' http object

' Create an xmlhttp object:

Set xml = Server.CreateObject("Microsoft.XMLHTTP")

' Opens the connection to the WinSMS Gateway.
 xml.Open "GET", SendURL, False 

' Actually Sends the request and returns the result:
  xml.Send

  strBuffer=xml.ResponseText

' Parse response for error messages

If (Instr(strBuffer,"NOCREDITS") = 0) AND (Instr(strBuffer,"FAIL") = 0) AND (Instr(strBuffer,"INVALID") = 0) then
    Response.write("SENT")
else
    Response.write("FAILED:  " & strBuffer)
end if
  %>
