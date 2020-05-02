<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Graficador.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Graficación</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
        <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable(<%=DameDatos()%>);

            var options = {
                title: 'Los 10 países y/o territorios más extensos del mundo',
                hAxis: {
                    title: 'País'
                },
                vAxis: {
                    title: 'Extensión en en km²'
                }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('chart'));

            chart.draw(data, options);
        }
    </script>
</head>
<body class="d-flex flex-column h-100">
    <header class="py-1">
        <div class="row flex-nowrap justify-content-between align-items-center">
            <div class="col-4 text-center">
                <h1><a class="header-logo text-dark" href="#">Google Charts</a></h1>
            </div>
        </div>
    </header>
    <div class="container p-3 mb-2">
        <form id="form1" runat="server">
            <div id="chart" style="width: 900px; height: 500px;"></div>
        </form>
    </div>
    <footer class="mt-auto py-3">
        <p>by <a href="http:\\www.itsur.edu.mx">Instituto Tecnológico Superior del Sur de Guanajuato</a>.</p>
        <p>Programación Web III</p>
    </footer>
    <script src="js/jquery-3.4.1.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
