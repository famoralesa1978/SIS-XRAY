<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EnviarConsultaCertificaciones.aspx.cs" Inherits="SIS_XRAY.Contacto.EnviarConsulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- BEGIN CONTENT-->
			<div id="content">
				<section class="has-actions style-default-bright">

					<!-- BEGIN INBOX -->
					<div class="section-body">
						<div class="row">
							<!-- BEGIN MAIL COMPOSE -->
							<div class="col-sm-8 col-md-9 col-lg-10">
								<h3>Certificados</h3>
								<form class="form" id="formCompose" >
									<div class="form-group floating-label">
										<input type="text" class="form-control" id="Subject1" name="Subject1" runat="server" >
										<label for="Subject1">Asunto</label>
									</div><!--end .form-group -->
									<div class="form-group">
										<textarea id="message"  runat="server"  name="message" class="form-control control-12-rows" spellcheck="false"></textarea>
									</div><!--end .form-group -->
									<div class="form-group">
										<asp:FileUpload ID="FileUpload1" runat="server" />
									</div><!--end .form-group -->
								</form>
							</div><!--end .col -->
							<!-- END MAIL COMPOSE -->

						</div><!--end .row -->
					</div><!--end .section-body -->
					<!-- END INBOX -->

					<!-- BEGIN SECTION ACTION -->
					<div class="section-action style-primary">
						<div class="section-action-row">
							<a class="btn ink-reaction btn-icon-toggle" href="../Principal.aspx"><i class="fa fa-chevron-left"></i></a>
						</div>
						<div class="section-floating-action-row">
							<asp:Button ID="btnEnviar" class="btn btn-block ink-reaction btn-accent-light" runat="server" Text="Enviar correo" ValidationGroup="Ingresar" OnClick="btnEnviar_Click" />
						</div>
					</div>
					<!-- END SECTION ACTION -->

				</section>
			</div><!--end #content-->
			<!-- END CONTENT -->
</asp:Content>
