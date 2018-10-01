<?php
$ini = parse_ini_file('config.ini');

$usertable_name = $ini['mybb_usertable'];

$link = mysqli_connect($ini['db_host'], $ini['db_user'], $ini['db_password']);
$database = mysqli_select_db($link, $ini['db_name']);

$user = $_GET['username'];
$password = $_GET['password'];

$user_sql = mysqli_real_escape_string($link, $user);

$sql = "SELECT * FROM $usertable_name WHERE `username` = '$user_sql'" ;
$result = $link->query($sql);

if ($result->num_rows > 0) {

	// Outputting the rows
	while($row = $result->fetch_assoc()) {
		
		$password_hash = md5(md5($row['salt']).md5($password));
		if($password_hash != $row['password']) {
			echo "0"; // Wrong pass, user exists
		}
		else {
			echo "1"; // Correct pass
		}
	}
} 
else {
	echo "2"; // User doesn't exist
}



//-----------------------------------------------------
// Coded by /id/Thaisen! Free loader source
// https://github.com/ThaisenPM/Cheat-Loader-CSGO-2.0
// Note to the person using this, removing this
// text is in violation of the license you agreed
// to by downloading. Only you can see this so what
// does it matter anyways.
// Copyright © ThaisenPM 2017
// Licensed under a MIT license
// Read the terms of the license here
// https://github.com/ThaisenPM/Cheat-Loader-CSGO-2.0/blob/master/LICENSE
//-----------------------------------------------------
?>

<head>
<title>Checking login info</title>
</head>
