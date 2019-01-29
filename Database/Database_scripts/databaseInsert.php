<?php

	# Obtain POST Data
	//$variable1 = $_POST['var1'];
	//$variable2 = $_POST['var2'];
	//$variable3 = $_POST['var3'];
	$variable1 = 'male';
	$variable2 = 25;
	$variable3 = 'maltese';
	
	# Include database connection file
	include("connection.php");
		
	# Insert transaction in database
	$stmt = $connect->prepare('INSERT INTO player_table(Gender,Age,Nationality) VALUES(?,?,?)');
	$stmt->bind_param('ss', $variable1, $variable2, $variable3);							
	$stmt->execute();
	$stmt->close();
	
	echo "Done...";
	
?>