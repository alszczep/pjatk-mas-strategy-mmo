import { useEffect, useState } from "react"
import styled from "styled-components"

const StyledApp = styled.div`
  // Your style here
`

export function App() {
  const [data, setData] = useState<any>()

  const fetchData = async () => {
    const response = await fetch("http://localhost:5152/weatherforecast")
    const data = await response.json()
    setData(data)
  }

  useEffect(() => {
    fetchData()
  }, [])

  return <StyledApp>{JSON.stringify(data)}</StyledApp>
}

export default App
