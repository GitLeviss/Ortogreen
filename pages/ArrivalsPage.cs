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
    public class ArrivalsPage
    {
        Utils utils;
        private readonly IPage page;

        public ArrivalsPage(IPage page)
        {
            this.page = page;
            utils = new Utils(page);
        }

        public async Task ScheduleAppointment()
        {
            
            await page.GetByRole(AriaRole.Complementary).GetByText("Agenda").ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Chegadas" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Nova Consulta" }).ClickAsync();
            await page.Locator(".n-base-selection-input").First.ClickAsync();
            await page.GetByText("User Teste").ClickAsync();
            await page.Locator("form").GetByRole(AriaRole.Textbox).First.ClickAsync();
            await page.GetByText("Dr. QA (CRO: 221345)").ClickAsync();
            await page.Locator("form").GetByRole(AriaRole.Textbox).Nth(1).ClickAsync();
            await page.GetByText("Canal (90 min)").ClickAsync();
            await page.Locator(".n-radio__dot").First.ClickAsync();
            await page.GetByRole(AriaRole.Textbox, new() { Name = "Ex: Sala 1, Consultório A" }).FillAsync("Sala 8 Consultorio B");
            await page.GetByTitle("Normal").Locator("div").ClickAsync();
            await page.GetByText("Alta").ClickAsync();
            await page.GetByRole(AriaRole.Textbox, new() { Name = "Observações sobre a consulta" }).FillAsync("Apenas Testando");
            
            await page.GetByRole(AriaRole.Button, new() { Name = "Confirmar Agendamento" }).ClickAsync();
            await page.GetByText("Consulta agendada com sucesso!").ClickAsync();
            await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar por paciente, dentista" }).ClickAsync();
            await page.GetByRole(AriaRole.Textbox, new() { Name = "Buscar por paciente, dentista" }).FillAsync("User Teste");
            await page.Locator(".n-input__prefix > svg").ClickAsync();
            await page.GetByText("User Teste").ClickAsync();
            await page.GetByTitle("Agendada").ClickAsync();
            await Expect(page.GetByText("User Teste")).ToBeVisibleAsync();
            await page.GetByTitle("Agendada").ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Confirmar" }).ClickAsync();
            await Expect(page.GetByText("1").Nth(2)).ToBeVisibleAsync();
            await page.GetByTitle("Confirmada").ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Check-in" }).ClickAsync();
            await Expect(page.GetByText("Check-in realizado com sucesso")).ToBeVisibleAsync();
            await page.GetByText("Check-in realizado!").ClickAsync();
            await page.GetByText("1").Nth(1).ClickAsync();
            await page.GetByTitle("Confirmada").ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Iniciar" }).ClickAsync();
            await Expect(page.GetByText("Atendimento iniciado com")).ToBeVisibleAsync();
            await page.GetByText("Atendimento iniciado!").ClickAsync();
            await Expect(page.GetByText("1").Nth(1)).ToBeVisibleAsync();
            await Expect(page.GetByTitle("Em Atendimento")).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Finalizar" }).ClickAsync();
            await Expect(page.GetByText("Atendimento finalizado com")).ToBeVisibleAsync();
            await page.GetByText("Atendimento finalizado!").ClickAsync();
            await Expect(page.GetByTitle("Concluída")).ToBeVisibleAsync();
            await Expect(page.GetByText("1").Nth(1)).ToBeVisibleAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Cancelar" }).ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Sim, cancelar" }).ClickAsync();
            await Expect(page.GetByText("Consulta cancelada com sucesso", new() { Exact = true })).ToBeVisibleAsync();
            await Expect(page.GetByText("Consulta cancelada com sucesso!")).ToBeVisibleAsync();
            await page.Locator(".n-statistic-value__content").First.ClickAsync();

            //await page.PauseAsync();
            
        }

    }
}
