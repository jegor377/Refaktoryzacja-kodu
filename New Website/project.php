<?php
function isOk($id)
{
	if(isset($_GET[$id]))
	{
		if(is_numeric($_GET[$id])) return true;
		return false;
	}
	return false;
}

if(isOk('id')) {
?>
<!DOCTYPE html>
<html lang="pl">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Igor Santarek</title>

    <link rel="Shortcut icon" href="img/icon.png"/> 
    
    <link rel="stylesheet" href="font-awesome/css/font-awesome.min.css">
    <link href='https://fonts.googleapis.com/css?family=Oswald|Lato:400,700&subset=latin,latin-ext' rel='stylesheet' type='text/css'>
      
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/slider.css" rel="stylesheet">
    <link href="css/home.css" rel="stylesheet">
	<link href="css/project.css" rel="stylesheet">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    
    <script src="js/slider.js"></script>
    <script src="js/sticker.js"></script>
    <script src="js/scrollerDelay.js"></script>
	<?php
		require_once "config.php";
		if (!$link = mysql_connect($host, $user, $password))
		{
			echo 'Failed to connect with database.';
			exit;
		}
		else
		{
			mysql_query("SET CHARSET utf8");
			mysql_query("SET NAMES 'utf8' COLLATE 'utf8_polish_ci'");
			if(!mysql_select_db($database, $link))
			{
				echo "Failed to connect with database.<br/>".mysql_error();
				exit;
			}
			else
			{
				$result = mysql_query("SELECT * FROM projects WHERE id = ".(int)$_GET['id'], $link);
				if(!$result)
				{
					echo "Failed to execute database question. (Or project just not exist...)\n".mysql_error();
					exit;
				}
				else
				{
					while($row = mysql_fetch_assoc($result))
					{
						$img = $row['images'];
						$name = $row['name'];
						$description = $row['description'];
						$link = $row['link'];
					}
				}
			}
		}
	?>
  </head>

  <body>
    <nav class="navbar navbar-default navbar-fixed-top remove-color">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#header">Igor Santarek</a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
          <ul class="nav navbar-nav link-color navbar-right">
            <li><a href="index.html#header">Home</a></li>
            <li><a href="index.html#about">About</a></li>
            <li><a href="index.html#portfolio">Portfolio</a></li>
            <li><a href="index.html#contact">Contact</a></li>
          </ul>
        </div>
      </div>
    </nav>

    <header id="header">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div id="welcome-box">
                        <div class="visible-lg visible-md visible-sm">
                            <img id="big-avatar" src="img/avatar.png" alt="avatar" class="img-circle"/>
                            <hr/>
                            <h1>Igor Santarek</h1>
                            <h4>Young programmer</h4>
                        </div>
                        <div class="visible-xs">
                            <img id="small-avatar" src="img/avatar.png" alt="avatar" class="img-circle"/>
                            <hr/>
                            <h3>Igor Santarek</h3>
                            <h6>Young programmer</h6>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </header>
    
    <section id="abilities" class="visible-lg visible-md visible-sm">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 not-visible-xs">
                    <div class="slider">
                        <div id="slider-window" class="slides">
                            <div id="slide1" class="slide">
                                <div class="device">
                                    <img src="img/ns_converter.png" width="260px" height="500px"/>
                                </div>
                                <div class="description">
                                    <div class="slider-title">
                                        <h1 class="visible-lg visible-md visible-sm">Smartphone apps</h1>
                                        <h3 class="visible-xs">Smartphone apps</h3>
                                    </div>
                                    <div class="slider-content">
                                        <ul>
                                            <li>Quick create</li>
                                            <li>Multiplatform</li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="slider-end"></div>
                            </div>
                            <div id="slide2" class="slide">
                                <div class="device">
                                    <img src="img/website.png" width="540px" height="460px"/>
                                </div>
                                <div class="description">
                                    <div class="slider-title">
                                        <h1 class="visible-lg visible-md visible-sm">Websites</h1>
                                        <h3 class="visible-xs">Websites</h3>
                                    </div>
                                    <div class="slider-content">
                                        <ul>
                                            <li>Shapely & nice</li>
                                            <li>Flat style</li>
                                            <li>Easy to use</li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="slider-end"></div>
                            </div>
                        </div>
                        <div id="slider-dots" class="dots">
                            <ul></ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
      
    <section id="about">
		<div class="container">
			<div class="row">
				<div class="col-lg-9 col-md-8 col-sm-8 col-xs-12">
					<div class="row">
						<h3 class="section-title"><?php echo $name; ?></h3>
					</div>
					<div class="row">
						<?php
							if($img != 'none')
							{
								$images[] = split($img, ';');
								foreach($image as $images)
								{
									echo "<img class='project-image' src='".$image."'/>";
								}
							}
						?>
					</div>
					<div class="row">
						<p class="text-justify">
							<?php
								if($description != "none") echo $description;
								else echo "It hasn't got any description";
							?>
						</p>
					</div>
					<div class="row">
						<?php
							if($link != "none") echo "<a href='".$link."'>".$link."</a>";
						?>
					</div>
				</div>
				<div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                    <a href="#header"><img id="ad-1" src="img/ad.jpg"/></a>
                </div>
			</div>
		</div>
	</section>
      
    <footer>
        <h4 class="visible-lg visible-md visible-sm">Copyright {{date}} &copy; Igor Santarek. All rights reserved.</h4>
        <h5 class="visible-xs">Copyright {{date}} &copy; Igor Santarek. All rights reserved.</h5>
    </footer>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/microAngular/microAngular.js"></script>
    <script src="js/projects.js"></script>
  </body>
</html>
<?php
}
else
{
	echo "YOU SHALL NOT PASS!";
	exit;
}