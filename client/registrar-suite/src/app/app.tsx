import { Home } from './features/Home/home';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Dropdown } from 'react-bootstrap';
import { rootSlice } from './features/Home/rootSlice';
import { RootState } from './store';
import { useDispatch, useSelector } from 'react-redux';

export function App() {
  const dispatch = useDispatch();
  const _root = useSelector((state: RootState) => state.root);

  const handleDropdownSelect = (eventKey: string | null) => {
    dispatch(rootSlice.actions.setRole(eventKey));
  };
  return (
    <div>
      <Navbar expand="lg" className="bg-body-tertiary">
        <Container>
          <Navbar.Brand href="#home">Registrar Suite</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link href="#home">Home</Nav.Link>
              <Dropdown onSelect={handleDropdownSelect}>
                <Dropdown.Toggle variant="secondary" id="dropdown-basic">
                  Choose User here
                </Dropdown.Toggle>

                <Dropdown.Menu>
                  <Dropdown.Item eventKey="Admin">Admin</Dropdown.Item>
                  <Dropdown.Item eventKey="Registrar">Registrar</Dropdown.Item>
                </Dropdown.Menu>
              </Dropdown>
              <Nav.Item>
                <Nav.Link disabled>
                  <span className="badge bg-primary">{_root.role}</span>
                </Nav.Link>
              </Nav.Item>
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
