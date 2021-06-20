<?xml version='1.0'?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" encoding="utf-8" indent="yes" doctype-system="about:legacy-compat" />

	<xsl:template match="/">
		<html>
			<head>
				<meta charset="utf-8" />
				<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
				<meta name="viewport" content="width=device-width"/>
				<title>GeneXus Developer Menu has moved!</title>
				<link rel="stylesheet" href="devmenu/developermenu.css" type="text/css" media="screen" />
				<style>
					p {
						position: fixed;
						left: 50%;
						top: 30%;
						transform: translateX(-50%);
						color: #333;
						font-size: 16px;
					}
				</style>
			</head>
			<body>
				<p><strong>Important!</strong> Now you can find the GeneXus Developer Menu <a href="developermenu.html">here</a></p>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
