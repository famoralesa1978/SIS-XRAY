﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecupararClave.aspx.cs" Inherits="SIS_XRAY.RecupararClave" %>

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
<body class="menubar-hoverable header-fixed ">
    <section class="section-account">
		<div class="img-backdrop" style="background-image: url('../../Recursos/assets/img/img16.jpg')">
            <div class="row">								
			    <%--<div class="col-xs-6 text-right">
                    <asp:HyperLink ID="hypVolver" runat="server" ImageUrl="~/Recursos/img/Home.png" CssClass="min-width:0%" ImageWidth="30px" ImageHeight="30px" NavigateUrl="~/index.aspx">Volver página Princpal</asp:HyperLink>
                </div>--%>
		    </div><!--end .row -->
		</div>
		<div class="spacer"></div>
		<div class="card contain-sm style-transparent">
			<div class="card-body">               
				<div class="row">
					<div class="col-sm-6">
						<br/>
						<span class="text-lg text-bold text-primary">Recuperar contraseña</span>
						<br/><br/>
						<form  runat="server" class="form floating-label"  accept-charset="utf-8" method="post">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
							<ContentTemplate>
							<div class="form-group">
                                <asp:TextBox ID="txtRut"  CssClass="form-control" ValidateRequestMode="Enabled" runat="server" MaxLength="50"  required="required" ValidationGroup="Ingresar"></asp:TextBox>
								<label for="username">Ingrese su rut</label>
							</div>
                            <div id="Captcha" class="form-group">
                                <asp:Image ID="Image2" runat="server" Height="55px" ImageUrl="~/Captcha.aspx" Width="186px" /> 
                                <asp:Button ID="btnRefrescar" runat="server" CausesValidation="false" ValidationGroup="Captchap" CssClass="md md-refresh" Text="refres" OnClick="btnRefrescar_Click"/>
                                <a href="__doPostBack('<%=UpdatePanel1.ClientID%>', 'RecuperarClave.aspx');return false;""><i class="md md-refresh"></i></a>
                                <br />  
                                <asp:Label runat="server" ID="lblCaptchaMessage"></asp:Label> 
							</div>
                            <div class="form-group">
                                <asp:TextBox runat="server" CssClass="form-control" required="required" ID="txtVerificationCode"></asp:TextBox>  
                                <label for="username">Código verificador</label>
							</div>
							<br/>
							<div class="row">								
								<div class="col-xs-6 text-right">
                                    <asp:Button ID="btnIngresar" class="btn btn-primary btn-raised" runat="server" Text="Recuperar contraseña" OnClick="btnIngresar_Click" ValidationGroup="Ingresar" />
                                    
								</div><!--end .col -->

								<div class="col-xs-6 text-right">
                                    <input type="button" class="btn btn-primary btn-raised" value="VOLVER" onclick="location.href = 'index.aspx'" />
								</div>

							</div><!--end .row -->
                                </ContentTemplate>

								<Triggers>
									<asp:AsyncPostBackTrigger ControlID ="btnIngresar" EventName="Click" />
                                   <asp:AsyncPostBackTrigger ControlID ="btnRefrescar" EventName="Click" /> 
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
    <script src="../../Recursos/js/general.js"></script>
</body>    
</html>
