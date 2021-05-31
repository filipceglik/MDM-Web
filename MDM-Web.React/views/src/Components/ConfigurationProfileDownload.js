import 'bootstrap'
import 'react-bootstrap'
import axios from "axios";
import blob from "axios"

function ConfigurationProfileDownload() {
    return (
        <div className="configuration-profile-download-component">
            <div className="card">
                <div className="card-body">
                    <h5>Pobierz plik konfiguracyjny</h5>
                    <button onClick={GetConfigurationProfile} className="btn btn-primary">Pobierz</button>
                </div>

            </div>
        </div>
    );
}

function GetConfigurationProfile(e) {
    e.preventDefault()
    var answer = window.confirm("Czy chcesz rozpocząć pobieranie profilu konfiguracyjnego?")
    if (answer) {
        const link = document.createElement('a');
        link.href = "https://mdm-mobileconfig.s3.eu-central-1.amazonaws.com/PafipiMDM.mobileconfig"
        document.body.appendChild(link)
        link.setAttribute("download", "PafipiMDM.mobileconfig")
        link.click()
        document.body.removeChild(link)
    }
}

export default ConfigurationProfileDownload;