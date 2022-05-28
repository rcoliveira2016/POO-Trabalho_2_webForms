<%@ Page Title="Cadastro Ordem de Serviço" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Trabalho_2_webForms.Paginas.OrdemServicos.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="titulo-pagina">
        <legend><%: Title %></legend>
        <div runat="server" id="divIdOrdemServico"> 
            <h4><strong>Numero Oredem Serviço: </strong><%: EntidadeCadastro.Id %></h4>
        </div>
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
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <label for="dllTipoFormaPagamento">Tipo Forma Pagamento</label>
                        <asp:DropDownList AutoPostBack="true" CssClass="form-control" ID="ddlTipoFormaPagamento" runat="server"  OnSelectedIndexChanged="ddlTipoFormaPagamento_SelectedIndexChanged" />
                    </div>
                </div>
            </div>
            <div runat="server" id="divPagamentoPix">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label for="txtCopiePix">Pix</label>
                            <asp:TextBox CssClass="form-control" Enabled="false" runat="server" ID="txtCopiaPix" />
                        </div>
                    </div>
                </div>
            </div>
             <div runat="server" id="divPagamentoBoleto">
                 <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label for="txtBoleto">Codigo de Barras</label>
                            <asp:TextBox CssClass="form-control" Enabled="false" runat="server" ID="txtBoleto" />
                        </div>
                    </div>
                </div>
            </div>
            <div runat="server" id="divPagamentoCartao">
                <div class="row">
                    <div class="col-lg-8">
                        <div class="form-group">
                            <label for="txtNumeroCartao">Numero cartao</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtNumeroCartao" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label for="txtCodigoSeguranca">Codigo segurança</label>
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtCodigoSeguranca" />
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <strong>Valor Total: </strong><span><%: ValorTotal %></span>
            </div>
        </fieldset>
        <asp:Button runat="server" Text="Salvar" ID="btnSalvar" CssClass="btn btn-default" OnClick="btnSalvar_Click" CommandName="_Salvar" />
    </fieldset>
</asp:Content>
