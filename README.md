# Treinamento de Ransomware

## Visão Geral

<p>Este projeto é um aplicativo de console projetado para fins de treinamento de ransomware. Ele demonstra processos de criptografia, descriptografia e extração usando um cenário simulado de ransomware.</p>

## Funcionalidades

<ul>
  <li>Criptografa e descriptografa arquivos usando criptografia AES.</li>
  <li>Solicita ao usuário uma senha para descriptografar os arquivos.</li>
  <li>Exibe uma mensagem de resgate com instruções.</li>
  <li>Usa um arquivo XML para armazenar o status da criptografia e do pagamento.</li>
</ul>

## Pré-requisitos

<ul>
  <li><a href="https://dotnet.microsoft.com/download">SDK do .NET</a> (versão 8.0 ou posterior)</li>
  <li>Visual Studio ou qualquer IDE compatível com C#</li>
</ul>

## Instalação

<ol>
  <li>Clone o repositório:
    <pre><code>git clone https://github.com/seuusuario/ransomware-training.git
cd ransomware-training</code></pre>
  </li>
  <li>Abra a solução no Visual Studio ou na sua IDE preferida.</li>
  <li>Compile a solução para restaurar as dependências.</li>
</ol>

## Configuração

<ol>
  <li>Crie um arquivo <code>status.xml</code> no diretório <code>bin\Debug\net8.0</code> (ou build apropriado) com o seguinte conteúdo:
    <pre><code>&lt;status&gt;
    &lt;isPayed&gt;false&lt;/isPayed&gt;
    &lt;isEncrypted&gt;false&lt;/isEncrypted&gt;
    &lt;dir&gt;C:\Users\Public\Secret\&lt;/dir&gt;
    &lt;encryptionPassword&gt;password&lt;/encryptionPassword&gt;
&lt;/status&gt;
</code></pre>
  </li>
  <li>Certifique-se de que o diretório especificado na tag <code>dir</code> exista e contenha os arquivos a serem criptografados.</li>
</ol>

## Uso

<ol>
  <li>Execute o aplicativo. O aplicativo irá:
    <ul>
      <li>Criptografar os arquivos no diretório especificado.</li>
      <li>Exibir uma mensagem de resgate solicitando uma senha de descriptografia.</li>
    </ul>
  </li>
  <li>Digite a senha correta para descriptografar os arquivos. O status será atualizado no arquivo <code>status.xml</code>.</li>
</ol>

## Componentes Principais

<ul>
  <li><code>Program.cs</code>: O ponto de entrada principal para o aplicativo. Lida com os processos de criptografia e descriptografia.</li>
  <li><code>SecurityManager.cs</code>: Gerencia a leitura e atualização do status da criptografia no arquivo XML.</li>
  <li><code>RansomMessage.cs</code>: Contém a mensagem de resgate com arte ASCII.</li>
</ul>

## Aviso de Segurança

<p>Este projeto é destinado apenas para fins educacionais. Não deve ser usado para quaisquer atividades maliciosas. Sempre garanta que você tenha autorização adequada antes de executar esse tipo de software.</p>

## Disclaimer anti Script-Kiddies

<p><strong>Atenção:</strong> Este programa não possui técnicas de evasão e, portanto, não pode ser usado tecnicamente para fins maliciosos. Ele é projetado apenas para fins educacionais e de pesquisa, sem a capacidade de evitar detecções por software de segurança. O uso inadequado deste código é de sua exclusiva responsabilidade. Esteja ciente das leis de sua jurisdição e nunca use este código para violar a privacidade, segurança ou direitos de qualquer indivíduo ou organização.</p>

