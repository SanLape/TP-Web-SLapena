<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Vista.formArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>DETALLE DE ARTICULO
    </h1>

    <div class="card text-center mb-3" style="width: 18rem;">
        <img src="<%= art.imagen.urlImagen %>" class="card-img-top" alt="...">
        <div class="card-body">
            <h3 class="card-title"><%= art.nombre %></h3>
            <h5 class="card-text"><%= art.codigo %></h5>
            <p class="card-text"><%= art.descripcion %></p>
            <h5 class="card-text"><%= art.precio %></h5>
            <h5 class="card-text"><%= art.marca.nombre%></h5>
            <h5 class="card-text"><%= art.categoria.nombre%></h5>

        </div>
    </div>


</asp:Content>
