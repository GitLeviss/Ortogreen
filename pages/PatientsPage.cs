using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;
using Ortogreen.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ortogreen.pages
{
    public class PatientsPage
    {
        Utils utils;
        private readonly IPage page;

        public PatientsPage(IPage page) 
        {
            this.page = page;
            utils = new Utils(page);
        }

        public async Task RegisterNewPatient()
        {
            //await page.PauseAsync();

            try
            {
                await page.GetByRole(AriaRole.Link, new() { Name = "Pacientes" }).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Novo Paciente" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Nome completo do paciente" }).FillAsync("Paciente Testes");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "email@exemplo.com" }).FillAsync("emailteste@email.com");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "(11) 99999-" }).FillAsync("(11) 9341-25767");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Selecione a data" }).ClickAsync();
                await page.Locator("div:nth-child(32) > .n-date-panel-date__trigger").ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "-000" }).FillAsync("06240090");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Nome da rua" }).FillAsync("Rua pariquera açu");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Número" }).FillAsync("127");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Apto, Bloco, etc" }).FillAsync("casa");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Bairro" }).FillAsync("Munhoz Junior");
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Cidade" }).FillAsync("Osasco");
                await page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Estado$") }).GetByRole(AriaRole.Textbox).ClickAsync();
                await page.Locator("div").Filter(new() { HasTextRegex = new Regex("^Estado$") }).GetByRole(AriaRole.Textbox).FillAsync("SP");
                await page.GetByText("São Paulo (SP)").ClickAsync();

                await page.GetByRole(AriaRole.Textbox, new() { Name = "Informações adicionais sobre" }).FillAsync("apenas testando");
                await page.GetByRole(AriaRole.Button, new() { Name = "Criar Paciente" }).ClickAsync();
                await Expect(page.GetByText("Paciente criado com sucesso!")).ToBeVisibleAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar por nome, email," }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar por nome, email," }).FillAsync("Paciente Testes");               
                await page.Locator(".text-slate-400").First.ClickAsync();
                await Expect(page.GetByText("Paciente Testes")).ToBeVisibleAsync();
                await page.GetByText("Ativo", new() { Exact = true }).ClickAsync();
                await Expect(page.GetByText("Ativo", new() { Exact = true })).ToBeVisibleAsync();
            }
            catch
            {
                throw new PlaywrightException("Don´t possible Register a new Patient");
            }

            try
            {
                await page.GetByRole(AriaRole.Button, new() { Name = "Editar" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Nome completo do paciente" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Nome completo do paciente" }).FillAsync("Paciente Testes Editado");
                await page.GetByRole(AriaRole.Button, new() { Name = "Salvar Alterações" }).ClickAsync();
                await Expect(page.GetByText("Paciente atualizado com")).ToBeVisibleAsync();
            }
            catch
            {
                throw new PlaywrightException("Don´t possible Edit a Patient");
            }

            try
            {

                await page.GetByRole(AriaRole.Link, new() { Name = "Pacientes" }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar por nome, email," }).ClickAsync();
                await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar por nome, email," }).FillAsync("Paciente Testes Editado");

                await page.GetByRole(AriaRole.Button, new() { Name = "Excluir" }).ClickAsync();
                await page.GetByRole(AriaRole.Button, new() { Name = "Sim, excluir" }).ClickAsync();
                await page.GetByText("Paciente deletado com sucesso!").ClickAsync();
                await page.GetByText("Paciente excluído com sucesso").ClickAsync();
            }
            catch
            {
                throw new PlaywrightException("Don´t possible delete Patient");
            }

        }


    }
}
