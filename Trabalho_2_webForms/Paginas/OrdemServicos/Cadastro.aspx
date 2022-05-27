<%@ Page Title="Cadastro Ordem de Serviço" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Trabalho_2_webForms.Paginas.OrdemServicos.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="titulo-pagina">
        <legend><%: Title %></legend>
        <fieldset>
            <legend>Dados</legend>
            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        <label for="ddlCliente">Cliente:</label>
                        <asp:DropDownList AutoPostBack="false" CssClass="form-control" ID="ddlCliente" runat="server" _OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label for="ddlServico">Serviço:</label>
                        <asp:DropDownList AutoPostBack="false" CssClass="form-control" ID="ddlServico" runat="server"  _OnSelectedIndexChanged="ddlServico_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label for="ddlUsuario">Usuario:</label>
                        <asp:DropDownList AutoPostBack="false" CssClass="form-control" ID="ddlUsuario" runat="server"  _OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="txtValorUnitario">Unitario</label>
                        <asp:TextBox CssClass="form-control" TextMode="Number" runat="server" ID="txtUnitario" />
                    </div>
                </div>
            </div>
        </fieldset>
        <fieldset>
            <legend>Pagamento</legend>

        </fieldset>
        <asp:Button runat="server" Text="Salvar" ID="btnSalvar" CssClass="btn btn-default" OnClick="btnSalvar_Click" />
    </fieldset>
</asp:Content>
