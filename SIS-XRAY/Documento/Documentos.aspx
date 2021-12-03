<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Documentos.aspx.cs" Inherits="SIS_XRAY.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="base">

			<!-- BEGIN OFFCANVAS LEFT -->
			<div class="offcanvas">
			</div><!--end .offcanvas-->
			<!-- END OFFCANVAS LEFT -->

			<!-- BEGIN CONTENT-->
			<div id="content">
				<section>
					<div class="section-body contain-lg">
						<!-- BEGIN SELECT2 -->
						<div class="row">
							<div class="col-lg-12">
								<h4>Descarga documento</h4>
							</div><!--end .col -->
							<div class="col-lg-3 col-md-4">
								<article class="margin-bottom-xxl">
									<ul class="list-divided">
										<li>
											<asp:Image ID="Image1" runat="server" ImageUrl="~/Recursos/img/ArchivoDocumento.png" /></li>
									</ul>
								</article>
							</div><!--end .col -->
							<div class="col-lg-offset-1 col-md-8">
								<div class="card">
									<div class="card-body">
										<form class="form">
											<div class="form-group">
												<label>Año</label>
												<select class="form-control select2-list" >
													<asp:Substitution ID="subAnno" runat="server" MethodName="GetListadoAnno" />
													
												</select>
											</div>
											<div class="form-group">
												<label>Tipo documento</label>
												<select class="form-control select2-list" id="ListTipoDocumento"  runat="server">
												<%--	<asp:Substitution ID="subTipoDocumento" runat="server" MethodName="GetListadoTipoDocumento" />--%>
													
												</select>
											</div>
										</form>
									</div><!--end .card-body -->
								</div><!--end .card -->
							</div><!--end .col -->
						</div><!--end .row -->
						<!-- END SELECT2 -->
						<div class="row">
							<div class="col-lg-3 col-md-4">

							</div><!--end .col -->
							<div class="col-lg-offset-1 col-md-8">
								<div class="card">
									<div class="card-body">
											<div class="form-group">
												<asp:Button ID="btnBuscar" class="btn btn-primary btn-raised" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
											</div>
									</div><!--end .card-body -->
								</div><!--end .card -->
							</div><!--end .col -->
						</div><!--end .row -->
					</div><!--end .section-body -->
				</section>
			</div><!--end #content-->
			<!-- END CONTENT -->
		</div><!--end #base-->
		<!-- END BASE -->
</asp:Content>
