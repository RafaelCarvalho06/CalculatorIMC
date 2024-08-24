<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CalculatorIMC._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>IMC Calculator</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h2>Calculadora de IMC</h2>
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <label for="Nome">Nome:</label>
                            <asp:TextBox ID="Nome" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="Altura">Altura (em metros):</label>
                            <asp:TextBox ID="Altura" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="Peso">Peso (em kg):</label>
                            <asp:TextBox ID="Peso" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="CalculateButton" runat="server" Text="Calcular" CssClass="btn btn-primary" OnClick="CalculateButton_Click" />
                        <br /><br />
                        <asp:Label ID="ResultLabel" runat="server" Text="" CssClass="alert alert-info d-none"></asp:Label>
                        
                        <asp:Image ID="ResultImage" runat="server" Width="150px" Height="150px"></asp:Image>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
