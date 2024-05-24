export const apiFetch = async (
  endpoint: string,
  method: "GET" | "POST" | "PUT" | "DELETE",
  body?: object,
  options?: RequestInit,
) => {
  const response = await fetch(`http://localhost:5152/api/${endpoint}`, {
    body: body ? JSON.stringify(body) : undefined,
    method,
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.getItem("authToken")}`,
      credentials: "include",
      ...options?.headers,
    },
    ...options,
  })
  return await response.json()
}
