import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

const LoggedOutNavbar2 =()=>{
    return (
        <>
        <Navbar bg="dark" variant="dark">
            <Container>
            <Navbar.Brand href="/">Login</Navbar.Brand>
            </Container>
        </Navbar>
        </>
    )   
}
export default LoggedOutNavbar2;