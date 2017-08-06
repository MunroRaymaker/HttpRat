<?php
include("includes/header.php");

if (isset($_GET['page'])) {
  $page = $_GET['page'];
  $page = stripslashes($page);
  $page = strip_tags($page);
  $page = mysqli_real_escape_string($connect, $page);

  switch($page) {
    case "clients":
    include("clients.php");
    include("footer.php");
    break;

    case "login":
    include("login.php");
    include("footer.php");
    break;

    case "logout":
    include("logout.php");
    include("footer.php");
    break;

    case "command":
    include("command.php");
    include("footer");
    break;

    default:
    include("login.php");
    include("footer.php");
    break;
  }
}

 ?>
