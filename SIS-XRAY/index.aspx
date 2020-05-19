<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SIS_XRAY.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
    <link href="Recursos/Css/Login.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons"   rel="stylesheet">
</head>
<body>
    <form action="index.aspx" id="form1" runat="server" method="post">
    <div class="login-form">
        <div class="logo align-content-center">
            <img class="align-content-center" src="Recursos/Img/logoxr.jpg"/>
            <h4 class="text-center">Reportería X-Ray</h4> 
        </div>
    <div class ="form">
        
        <h4>Ingrese a su cuenta</h4>   
        <br />
        <div class="form-group">
        	<div class="input-group">
                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                <asp:TextBox ID="txtUsuario"  CssClass="form-control" ValidateRequestMode="Enabled" runat="server" MaxLength="50" placeholder="Usuario" required="required"></asp:TextBox>
            </div>
        </div>
		<div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="50" placeholder="Contraseña" required="required"></asp:TextBox>
            </div>
        </div>
        <br />        
        <div class="form-group">
            <asp:Button ID="btnIngresar" CssClass="btn btn-primary login-btn btn-block" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
        </div>
        <div class="clearfix">
            <i class="material-icons">lock_open</i>
            <span>Acceso sólo a personal autorizado.</span>
        </div>	
        </div>
        <p class="text-center text-muted small">Visitanos en.. <a href="www.detodoautos.cl">www.susitioweb.cl</a></p>
        </div>

        <div id="dialog-message" title="Error de Ingreso" style="display:none">
          <p>
            <span class="ui-icon ui-icon-circle-close" style="float:left; margin:0 7px 50px 0;"></span>
            Usuario o contraseña incorrecta, vuelva a intentarlo.
          </p>
        </div>

        <div id="dialog-UsrNoExiste" title="Error de Ingreso" style="display:none">
          <p>
            <span class="ui-icon ui-icon-circle-close" style="float:left; margin:0 7px 50px 0;"></span>
            Usuario es valido, pero no se encuenta registrado en el sistema.
          </p>
        </div>
    </form>
</body>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</html>
