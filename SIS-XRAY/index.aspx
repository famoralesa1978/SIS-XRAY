<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SIS_XRAY.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href='http://fonts.googleapis.com/css?family=Roboto:300italic,400italic,300,400,500,700,900' rel='stylesheet' type='text/css'/>
	<link type="text/css" rel="stylesheet" href="../../Recursos/assets/css/theme-default/bootstrap.css?1422792965" />
	<link type="text/css" rel="stylesheet" href="../../Recursos/assets/css/theme-default/materialadmin.css?1425466319" />
	<link type="text/css" rel="stylesheet" href="../../Recursos/assets/css/theme-default/font-awesome.min.css?1422529194" />
	<link type="text/css" rel="stylesheet" href="../../Recursos/assets/css/theme-default/material-design-iconic-font.min.css?1421434286" />
</head>
<body 
    >
    <%--<div class="login-form">
        <div class="logo align-content-center">
            <img class="align-content-center" src="Recursos/Img/logoxr.jpg"/>
            <h4 class="text-center">Reportería X-Ray</h4> 
        </div>
    <div class ="form">
        
        <h4>Ingrese a su cuenta - Primer Commit Páez</h4>   
        <br />
        <div class="form-group">
        	<div class="input-group">
                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                <asp:TextBox ID="txtUsuario"  CssClass="form-control" ValidateRequestMode="Enabled" runat="server" MaxLength="50" placeholder="Usuario" required="required" ValidationGroup="Ingresar"></asp:TextBox>
            </div>
        </div>
		<div class="form-group">
            <div class="input-group">
                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="50" placeholder="Contraseña" required="required" ValidationGroup="Ingresar"></asp:TextBox>
            </div>
        </div>
        <br />        
        <div class="form-group">
            <asp:Button ID="btnIngresar" CssClass="btn btn-primary login-btn btn-block" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" ValidationGroup="Ingresar" />
        </div>
        <div class="clearfix">
            <i class="material-icons">lock_open</i>
            <span>Acceso sólo a personal autorizado.</span>
        </div>	
        </div>
        <p class="text-center text-muted small">Visitanos en.. <a href="www.detodoautos.cl">www.susitioweb.cl</a></p>
        </div>
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div id="dialog-message" title="Error de Ingreso" style="display:none">
              <p>
                <span class="ui-icon ui-icon-circle-close" style="float:left; margin:0 7px 50px 0;"></span>
                Usuario o contraseña incorrecta, vuelva a intentarlo.
              </p>
            </div>
        </div>
        <div id="dialog-UsrNoExiste" title="Error de Ingreso" style="display:none">
          <p>
            <span class="ui-icon ui-icon-circle-close" style="float:left; margin:0 7px 50px 0;"></span>
            Usuario es valido, pero no se encuenta registrado en el sistema.
          </p>
        </div>--%>
        <section class="section-account">
			<div class="img-backdrop" style="background-image: url('../../Recursos/assets/img/img16.jpg')"></div>
			<div class="spacer"></div>
			<div class="card contain-sm style-transparent">
				<div class="card-body">
					<div class="row">
						<div class="col-sm-6">
							<br/>
							<span class="text-lg text-bold text-primary">Sistema de Informe de xray</span>
							<br/><br/>
							<%--<form  runat="server" class="form floating-label"  accept-charset="utf-8" method="post">--%>
                            <form action="index.aspx" id="form1" runat="server" method="post">
								<div class="form-group">
                                    <asp:TextBox ID="txtUsuario"  CssClass="form-control" ValidateRequestMode="Enabled" runat="server" MaxLength="50"  required="required" ValidationGroup="Ingresar"></asp:TextBox>
									<label for="username">Ingrese su rut</label>
								</div>
								<div class="form-group">
                                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="50"  required="required" ValidationGroup="Ingresar"></asp:TextBox>
									<label for="password">Password</label>
									<p class="help-block"><a href="#">Recordar contraseña?</a></p>
								</div>
								<br/>
								<div class="row">
									<div class="col-xs-6 text-left">
										<div class="checkbox checkbox-inline checkbox-styled">
											<label>
												<input type="checkbox"> <span>Remember me</span>
											</label>
										</div>
									</div><!--end .col -->
									<div class="col-xs-6 text-right">
                                        <asp:Button ID="btnIngresar" class="btn btn-primary btn-raised" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"  />
                                         <%--<asp:Button ID="Button1" CssClass="btn btn-primary login-btn btn-block" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />--%>
									</div><!--end .col -->
								</div><!--end .row -->


        <div id="dialog-message" title="Error de Ingreso" style="display:none">
          <p>
            <span class="ui-icon ui-icon-circle-close" style="float:left; margin:0 7px 50px 0;"></span>
            Usuario o contraseña INE incorrecta, vuelva a intentarlo.
          </p>
        </div>

        <div id="dialog-UsrNoExiste" title="Error de Ingreso" style="display:none">
          <p>
            <span class="ui-icon ui-icon-circle-close" style="float:left; margin:0 7px 50px 0;"></span>
            Usuario es valido, pero no se encuenta registrado en el sistema.
          </p>
        </div>


							</form>
						</div><!--end .col -->
					</div><!--end .row -->
				</div><!--end .card-body -->
			</div><!--end .card -->
		</section>



    <script src="../../Recursos/assets/js/libs/jquery/jquery-1.11.2.min.js"></script>
	<script src="../../Recursos/assets/js/libs/jquery/jquery-migrate-1.2.1.min.js"></script>
	<script src="../../Recursos/assets/js/libs/bootstrap/bootstrap.min.js"></script>
	<script src="../../Recursos/assets/js/libs/spin.js/spin.min.js"></script>
	<script src="../../Recursos/assets/js/libs/autosize/jquery.autosize.min.js"></script>
	<script src="../../Recursos/assets/js/libs/nanoscroller/jquery.nanoscroller.min.js"></script>
	<script src="../../Recursos/assets/js/core/source/App.js"></script>
	<script src="../../Recursos/assets/js/core/source/AppNavigation.js"></script>
	<script src="../../Recursos/assets/js/core/source/AppOffcanvas.js"></script>
	<script src="../../Recursos/assets/js/core/source/AppCard.js"></script>
	<script src="../../Recursos/assets/js/core/source/AppForm.js"></script>
	<script src="../../Recursos/assets/js/core/source/AppNavSearch.js"></script>
	<script src="../../Recursos/assets/js/core/source/AppVendor.js"></script>
	<script src="../../Recursos/assets/js/core/demo/Demo.js"></script>
       <script src="../../Recursos/js/general.js"></script>
</body>    
</html>
