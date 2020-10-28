<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="SIS_XRAY.Contacto.Contacto" %>
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
								<h3>Enviar consulta</h3>
								<form class="form" id="formCompose">
									<div class="form-group floating-label">
										<input type="email" class="form-control" id="to1" name="to1" >
										<label for="to1">To</label>
										<a class="link-default pull-right" href="#emailOptions" data-toggle="collapse">More</a>
									</div><!--end .form-group -->
									<div id="emailOptions" class="collapse">
										<div class="form-group floating-label">
											<input type="email" class="form-control" id="cc1" name="cc1" >
											<label for="cc1">CC</label>
										</div><!--end .form-group -->
										<div class="form-group floating-label">
											<input type="email" class="form-control" id="bcc1" name="bcc1" >
											<label for="bcc1">BCC</label>
										</div><!--end .form-group -->
									</div><!--end #emailOptions -->
									<div class="form-group floating-label">
										<input type="text" class="form-control" id="Subject1" name="Subject1" >
										<label for="Subject1">Subject</label>
									</div><!--end .form-group -->
									<div class="form-group">
										<textarea id="simple-summernote" name="message" class="form-control control-6-rows" spellcheck="false"></textarea>
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
							<a class="btn ink-reaction btn-icon-toggle" href="../../html/mail/inbox.html"><i class="fa fa-chevron-left"></i></a>
						</div>
						<div class="section-floating-action-row">
							<a class="btn ink-reaction btn-floating-action btn-lg btn-accent" href="#formCompose" data-submit="form"><i class="md md-send"></i></a>
						</div>
					</div>
					<!-- END SECTION ACTION -->

				</section>
			</div><!--end #content-->
			<!-- END CONTENT -->
</asp:Content>
