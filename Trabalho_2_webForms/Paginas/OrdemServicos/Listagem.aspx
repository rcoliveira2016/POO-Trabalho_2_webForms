﻿<%@ Page Title="Listagem Ordem de Serviços" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listagem.aspx.cs" Inherits="Trabalho_2_webForms.Paginas.OrdemServicos.Listagem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="titulo-pagina">
        <legend><%: Title %></legend>
        <div class="row">
            <div class="col-12">
                <a runat="server" class="btn btn-btn-default" href="~/Paginas/OrdemServicos/Cadastro.aspx">Novo Ordem de Serviço</a>
            </div>
        </div>
        <asp:GridView ID="grdDados" 
            runat="server" 
            AutoGenerateColumns="false" 
            AutoGenerateDeleteButton="true"
            AutoGenerateEditButton="true"
            OnRowDeleting="grdDados_RowDeleting" 
            OnRowEditing="grdDados_RowEditing"
            CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Codigo" />
                <asp:BoundField DataField="ClienteDescricao" HeaderText="Cliente" />
                <asp:BoundField DataField="UsuarioDescricao" HeaderText="Usuário" />
                <asp:BoundField DataField="ServicoDescricao" HeaderText="Serviço" />
                <asp:BoundField DataField="ValorTotal" HeaderText="Valor" />
                <asp:BoundField DataField="DataAbertura" HeaderText="Data da abertura" />
            </Columns>
        </asp:GridView>
    </fieldset>
</asp:Content>
