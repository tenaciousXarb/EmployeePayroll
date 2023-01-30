import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

const LoggedEmpNavbar =()=>{
    return (
        <>
        <Navbar bg="dark" variant="dark">
            <Container>
            <Navbar.Brand href="/employee/home">Employee</Navbar.Brand>
            <Nav className="me-auto">
                <Nav.Link href="/employee/leaveapplication">Leave</Nav.Link>
                <Nav.Link href="/employee/salaryreport">Salary Report</Nav.Link>
                <Nav.Link href="/employee/changepassword">Change Password</Nav.Link>
                <Nav.Link href="/employees/logout">Logout</Nav.Link>
            </Nav>
            </Container>
        </Navbar>
        </>
    )   
}
export default LoggedEmpNavbar;