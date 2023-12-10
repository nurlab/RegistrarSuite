import { Home } from './features/Home/home';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';

export function App() {
  return (
    <div>
      <Navbar expand="lg" className="bg-body-tertiary">
        <Container>
          <Navbar.Brand href="#home">Registrar Suite</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link href="#home">Home</Nav.Link>
              <NavDropdown title="Choose User here" id="basic-nav-dropdown">
                <NavDropdown.Item href="#action/3.2">Admin</NavDropdown.Item>
                <NavDropdown.Item href="#action/3.3">
                  Registrar
                </NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <div className="container mt-4">
        <div className="row justify-content-center">
          <div className="col-md-9">
            <Home />
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
