using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace MicrosipConfig
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e) {
            try
            {
                string setor = comboSetor.SelectedItem?.ToString();
                string ramal = txtRamal.Text.Trim();
                string interno = radioInterno.Checked ? "interno" : "externo";

                if (string.IsNullOrEmpty(setor) || string.IsNullOrEmpty(ramal))
                {
                    MessageBox.Show("Por favor, preencha ambos os campos (Setor e Ramal).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nomeArquivo = "Contacts.xml";
                string caminhoIni = "microsip.ini";

                if (GerarContatos(nomeArquivo, ramal, setor))
                {
                    ConfigurarMicrosip(caminhoIni, ramal, interno);
                    MessageBox.Show("Arquivos gerados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            } catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Execute em modo administrador", "Erro de Permissão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch(Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GerarContatos(string nomeArquivo, string ramal, string setor) {
            Dictionary<string, List<Contato>> setores = new Dictionary<string, List<Contato>>()
            {
                {"CALL_CENTER", new List<Contato>
                    {
                        new Contato($"*4700*{ramal}", "CANCELAMENTO"),
                        new Contato($"*4300*{ramal}", "GIGALINE - COMERCIAL"),
                        new Contato($"*4100*{ramal}", "GIGALINE - FINANCEIRO"),
                        new Contato($"*4200*{ramal}", "GIGALINE - SUPORTE"),
                        new Contato($"*4600*{ramal}", "LESTE - COMERCIAL"),
                        new Contato($"*4400*{ramal}", "LESTE - FINANCEIRO"),
                        new Contato($"*4500*{ramal}", "LESTE - SUPORTE"),
                        new Contato($"*56*{ramal}", "PAUSA - BANHEIRO"),
                        new Contato($"*58*{ramal}", "PAUSA - PADRAO"),
                        new Contato($"*55*{ramal}", "PAUSA - REFEIÇÃO"),
                        new Contato($"*57*{ramal}", "RETORNO")
                    }
                },
                {"CC_ATENDIMENTO", new List<Contato>
                    {
                        new Contato($"*4700*{ramal}", "CANCELAMENTO"),
                        new Contato($"*4701*{ramal}", "LESTE - ATENDIMENTO"),
                        new Contato($"*4300*{ramal}", "GIGALINE - COMERCIAL"),
                        new Contato($"*4100*{ramal}", "GIGALINE - FINANCEIRO"),
                        new Contato($"*4200*{ramal}", "GIGALINE - SUPORTE"),
                        new Contato($"*4600*{ramal}", "LESTE - COMERCIAL"),
                        new Contato($"*4400*{ramal}", "LESTE - FINANCEIRO"),
                        new Contato($"*4500*{ramal}", "LESTE - SUPORTE"),
                        new Contato($"*56*{ramal}", "PAUSA - BANHEIRO"),
                        new Contato($"*58*{ramal}", "PAUSA - PADRAO"),
                        new Contato($"*55*{ramal}", "PAUSA - REFEIÇÃO"),
                        new Contato($"*57*{ramal}", "RETORNO")
                    }
                },
                {"LOGISTICA", new List<Contato>
                    {
                        new Contato($"*4800*{ramal}", "LOGISTICA ")
                    }
                }
            };

            if (setores.ContainsKey(setor)) {
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement raiz = xmlDoc.CreateElement("contacts");
                xmlDoc.AppendChild(raiz);

                foreach (var contato in setores[setor]) {
                    XmlElement contatoElement = xmlDoc.CreateElement("contact");
                    contatoElement.SetAttribute("number", contato.Number);
                    contatoElement.SetAttribute("name", contato.Name);
                    contatoElement.SetAttribute("presence", "0");
                    contatoElement.SetAttribute("directory", "0");
                    contatoElement.InnerText = " ";
                    raiz.AppendChild(contatoElement);
                }

                // formatar o XML com indentação
                xmlDoc.PreserveWhitespace = true;
                StringWriter stringWriter = new StringWriter();
                XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);
                xmlDoc.Save(xmlWriter);
                File.WriteAllText(nomeArquivo, stringWriter.ToString());

                return true;
            }

            return false;
        }

        private void ConfigurarMicrosip(string caminhoArquivo, string ramal, string interno) {
            string ipInterno = "192.168.100.247";
            string ipExterno = "10.201.192.34";
            string ip = interno == "interno" ? ipInterno : ipExterno;

            using (StreamWriter writer = new StreamWriter(caminhoArquivo)) { 
                writer.WriteLine("[Settings]");
                writer.WriteLine("updateInterval=never");
                writer.WriteLine("accountId=1");
                writer.WriteLine("autoAnswer=0");
                writer.WriteLine("denyIncoming=0");
                writer.WriteLine("ip=" + ip);
                writer.WriteLine("ramal=" + ramal);
            }
        }

        public class Contato
        {
            public string Number { get; set; }
            public string Name { get; set; }

            public Contato(string number, string name) {
                Number = number;
                Name = name;
            }
        }
    }
}
