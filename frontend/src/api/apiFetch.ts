export const apiFetch = async (endpoint: string, options?: RequestInit) => {
  const response = await fetch(`http://localhost:5152/${endpoint}`, options)
  return await response.json()
}
