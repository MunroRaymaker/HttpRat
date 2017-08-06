<?php
include("includes/connect.php");
session_start();

if (!isset($_SESSION['username'])) {
  $login = "true";
  $username = "Not logged in";
}else{
  $username = $_SESSION['username'];
}
?>

<html>
  <head>
    <title>PHP RAT</title>
    <link rel="stylesheet" type="text/css" href="styles/style.css">
    <link rel="stylesheet" type="text/css" href="styles/font-awesome/css/font-awesome.css">
    <link href="https://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet">
  </head>
  <body>

    <ul class="topBar">
      <li class="topBarItems" style="float: right; color: #fff; padding-top: 15px; padding: 8px 15px;"><i class="fa fa-user" aria-hidden="true"></i> <?php echo $username?></li>
    </ul>

    <ul class="SideBar">
      <li class="SideBarMenu"><a href="index.php?page=clients"><i class="fa fa-link" aria-hidden="true"></i> Clients</a></li>
      <?php
        if ($login == "true") {
          echo '<li class="SideBarMenu"><a href="index.php?page=login"><i class="fa fa-sign-in" aria-hidden="true"></i> Login</a></li>';
        }else{
          echo '<li class="SideBarMenu"><a href="index.php?page=logout"><i class="fa fa-sign-out" aria-hidden="true"></i> Logout</a></li>';
        }
       ?>
      <li class="SideBarMenu"><a href="index.php?page=usercp"><i class="fa fa-cogs" aria-hidden="true"></i> Settings</a></li>
    </ul>

    <div class="content">
