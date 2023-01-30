import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

const LoggedOutNavbar =()=>{
    return (
        <>
        <Navbar bg="dark" variant="dark">
            <Container>
            <Navbar.Brand href="/employee/registration">Employee Registration</Navbar.Brand>
            </Container>
        </Navbar>
        </>
    )   
}
export default LoggedOutNavbar;