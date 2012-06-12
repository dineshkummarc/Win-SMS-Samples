<?php
$url = 'http://www.winsms.co.za/api/batchmessage.asp?user=username&password=password&message=PhpTest&Numbers=27xxxxxxxxx;';

$fp = fopen($url, 'r');

while(!feof($fp)){
$line = fgets($fp, 4000);
print($line);
echo "<br>";
}
fclose($fp);


/*Now Parse $line to determine if errors were encountered, and to obtain the Server ID for each message sent.

Ensure that fopen_allow_url is set to true in php.ini (it is by default).

If the web server is behind a firewall or proxy server, you will have to open it for the php script, or alternatively look into setting the proxy settings for authentication in the .php script.
*/

?>



