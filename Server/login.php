<?php
if (isset($_POST['login'])) {
  //Begin login script
  $username = $_POST['username'];
  $password = $_POST['password'];

  $username = stripslashes($username);
  $username = strip_tags($username);
  $username = mysqli_real_escape_string($connect, $username);

  $password = stripslashes($password);
  $password = strip_tags($password);
  $password = mysqli_real_escape_string($connect, $password);
  $password = hash("sha256", $password);

  $sql = "SELECT * FROM users WHERE username='$username' LIMIT 1";
  $query = mysqli_query($connect, $sql);
  $rows = mysqli_num_rows($query);

    if ($rows == 1) {
      //User exists in the database
      $rowArray = mysqli_fetch_array($query);
      $dbUsername = $rowArray['username'];
      $dbPassword = $rowArray['password'];
        if ($dbUsername == $username && $dbPassword == $password) {
          //Username & Password is correct
          session_start();
          $_SESSION['username'] = $username;
          header('Location: index.php?page=clients');
        }else{
          $loginError = "Incorrect Username or Password!";
        }
    }else{
      $loginError = "Incorrect Username or Password!";
    }
}
 ?>

<div class="loginDiv" align="center" style="margin-top: 10%;">
   <form action="index.php?page=login" method="POST">
     <table border="0">
       <tr>
         <td>Username: </td>
         <td width="600"><input class="login" id="username" type="text" name="username"></td>
       </tr>
       <tr>
         <td>Password: </td>
         <td><input class="login" id="password" type="password" name="password"></td>
       </tr>
       <tr>
         <td></td>
         <td><input type="submit" name="login" class="loginBtn"></td>
       </tr>
       <tr>
         <td></td>
         <td>
          <?php
            if (isset($loginError)) {
              echo '<font color="red">'.$loginError;
            }
           ?>
         </td>
       </tr>
    </table>
   </form>
 </div>
