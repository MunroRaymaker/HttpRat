<?php
include ("includes/connect.php");

if(isset($_GET['check'])){
    $hash = $_GET['hash'];
    $hash = stripslashes($hash);
    $hash = strip_tags($hash);
    $hash = mysqli_real_escape_string($connect, $hash);

    $sql = "SELECT * FROM clients WHERE hash = '$hash' LIMIT 1";
    $query = mysqli_query($connect, $sql);
    $rows = mysqli_num_rows($query);

    if($rows != 0){
        $rowArray = mysqli_fetch_array($query);
        $clientid = $rowArray['clientid'];
        echo $clientid;

        $sql = "UPDATE clients SET online = '1' WHERE clientid = '$clientid'";
        $query = mysqli_query($connect, $sql);
    } else {
        echo 'false';
    }    
}

if(isset($_GET['new'])){
    $hash = $_GET['hash'];
    $hash = stripslashes($hash);
    $hash = strip_tags($hash);
    $hash = mysqli_real_escape_string($connect, $hash);
    
    $hostname = $_GET['hostname'];
    $hostname = stripslashes($hostname);
    $hostname = strip_tags($hostname);
    $hostname = mysqli_real_escape_string($connect, $hostname);

    $ipaddress = $_GET['ipaddress'];
    $ipaddress = stripslashes($ipaddress);
    $ipaddress = strip_tags($ipaddress);
    $ipaddress = mysqli_real_escape_string($connect, $ipaddress);

    $os = $_GET['os'];
    $os = stripslashes($os);
    $os = strip_tags($os);
    $os = mysqli_real_escape_string($connect, $os);

    $sql = "INSERT INTO clients (hash, hostname, ipaddress, os, online) VALUES ('$hash', '$hostname', '$ipaddress', '$os', '1')";
    $query = mysqli_query($connect, $sql);
    $clientid = mysqli_insert_id($connect);
    echo $clientid;
    #echo mysqli_error($connect);    
}

?>
