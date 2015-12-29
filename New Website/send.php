<html>
	<head>
	
	</head>
	
	<body>
		<?php
		if(isset($_POST['submit'])){
						$to = "jegor377@gmail.com";
						$from = $_POST['email'];
						$subject = "Wiadomość z twojej strony";
						$message = "Dostałeś wiadomość:" . "\n\n" . $_POST['message'];
						
						$headers = "Od:" . $from;
						mail($to,$subject,$message,$headers);
		}
		?>
		<script type="text/javascript">
			window.location = "index.html";
		</script>
	</body>

</html>