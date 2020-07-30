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
    <link type="text/css" rel="stylesheet" href="../../Recursos/assets/css/theme-default/libs/toastr/toastr.css?1425466569" />
</head>
<body class="menubar-hoverable header-fixed ">
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
                        <form  runat="server" class="form floating-label"  accept-charset="utf-8" method="post">

                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
								<ContentTemplate>
									<div class="form-group">
										<asp:TextBox ID="txtUsuario"  CssClass="form-control" ValidateRequestMode="Enabled" runat="server" MaxLength="50"  required="required" ValidationGroup="Ingresar"></asp:TextBox>
										<label for="username">Ingrese su rut</label>
									</div>
									<div class="form-group">
										<asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password" MaxLength="50"  required="required" ValidationGroup="Ingresar"></asp:TextBox>
										<label for="password">Password</label>
										<p class="help-block"><a href="RecupararClave.aspx">Recordar contraseña?</a></p>
									</div>
									<br/>
									<div class="row">
										<div class="col-xs-6 text-left">
											<div class="checkbox checkbox-inline checkbox-styled">
												<label>
												</label>
											</div>
										</div><!--end .col -->
										<div class="col-xs-6 text-right">
											<asp:Button ID="btnIngresar" class="btn btn-primary btn-raised" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"  />
										 </div><!--end .col -->
									</div><!--end .row -->

									<div id="mje_error" title="Error de Ingreso" style="display:none">
									  <p>
										<span class="ui-icon ui-icon-circle-close" style="float:left; margin:0 7px 50px 0;"></span>
										Usuario o contraseña incorrecta, vuelva a intentarlo.
									  </p>
									</div>
								</ContentTemplate>

								<Triggers>
									<asp:AsyncPostBackTrigger ControlID ="btnIngresar" EventName="Click" />
								</Triggers>

                            </asp:UpdatePanel>
						</form>
					</div><!--end .col -->
				</div><!--end .row -->
			</div><!--end .card-body -->
		</div><!--end .card -->
	</section>
    <script src="../../Recursos/assets/js/libs/jquery/jquery-1.11.2.min.js"></script>
	<script src="../../Recursos/assets/js/libs/jquery/jquery-migrate-1.2.1.min.js"></script>
    <script src="../../Recursos/assets/js/libs/toastr/toastr.js"></script>
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
    <script src="../../Recursos/assets/js/libs/Mensaje/UIMessages.js"></script>

<script src="https://code.jquery.com/ui/1.11.1/jquery-ui.min.js"></script>
	<link rel="stylesheet" href="https://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css" />

    <script src="../../Recursos/js/general.js"></script>
</body> 
</html>
