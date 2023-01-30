import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

const LoggedAdminNavbar =()=>{
    return (
        <>
        <Navbar bg="dark" variant="dark">
            <Container>
            <Navbar.Brand href="/admins/show">Admin</Navbar.Brand>
            <Nav className="me-auto">
                <Nav.Link href="/admins/stats">Statistics</Nav.Link>
                <Nav.Link href="/departments">Departments</Nav.Link>
                <Nav.Link href="/admins/leaves">Pending Leaves</Nav.Link>
                <Nav.Link href="/admins/logout">Logout</Nav.Link>
            </Nav>
            </Container>
        </Navbar>
        </>
    )   
}
export default LoggedAdminNavbar;