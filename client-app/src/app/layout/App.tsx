import { Container } from 'semantic-ui-react'
import NavBar from './NavBar';
import { observer } from 'mobx-react-lite';
import { Outlet, useLocation } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import { ToastContainer } from 'react-toastify';


function App() {
  //const [count, setCount] = useState(0)

  const location = useLocation();

  return (
    <>
    <ToastContainer position='bottom-center' hideProgressBar theme='colored' />
    {location.pathname === '/' ? <HomePage /> : (
      <>
      <NavBar />
      <Container style={{marginTop: '7em'}}>
        <Outlet  />
      </Container>
      </>    
    )}
    </>
  );
}

export default observer(App)
