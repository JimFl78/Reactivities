import { useEffect, useState } from 'react'
import axios from 'axios'
import { Container, Header, List, Segment } from 'semantic-ui-react'


function App() {
  //const [count, setCount] = useState(0)
  const [activities, setActivities] = useState([])

  useEffect(() => {
    axios.get('http://localhost:5000/api/activities')
    .then(response =>{
      setActivities(response.data)
    })
  }, [])

  return (
    <div className="App">
      <Container>
      <Header as='h2' attached='top'>
      Activities
    </Header>
    <Segment attached>
    <List bulleted>
        {activities.map((activity: any) => (
          <List.Item key={activity.id}>
            {activity.title}
          </List.Item> 
        ))}
      </List>
    </Segment>
      
      </Container>
    </div>
    
  )
}

export default App
