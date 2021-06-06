import 'bootstrap'
import 'react-bootstrap'
import '../css/HomePage.css'


function HomePage() {

    return (
        <div className="container card">
            <div className="row card-header table-header pt-2 pb-2">
                <div className="col-12 col-md-6">

                </div>
                <div className="col-12 col-md-6 text-right ">
                    <button className="btn btn-success m-1 ">Dodaj nowy</button>
                    <button className="btn btn-danger m-1">Usuń zaznaczone</button>
                </div>
            </div>
            <div className="row card-body border-bottom">
                <div className="col-3">
                    test
                </div>
                <div className="col-3">
                    test
                </div>
                <div className="col-3">
                    test
                </div>
                <div className="col-3">

                </div>
            </div>
            <div className="row card-body border-bottom">
                <div className="col-3">
                    test
                </div>
                <div className="col-3">
                    test
                </div>
                <div className="col-3">
                    test
                </div>
                <div className="col-3">

                </div>
            </div>
        </div>
    )
}

export default HomePage;