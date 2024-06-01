export const buildingGridHeight = 6
export const buildingGridWidth = 6

type GridArea = {
  gridRow: number
  gridColumn: number
}

export const buildingPlaceToGridPosition: GridArea[] & { length: 10 } = [
  {
    gridRow: 5,
    gridColumn: 20,
  },
  {
    gridRow: 6,
    gridColumn: 31,
  },
  {
    gridRow: 14,
    gridColumn: 9,
  },
  {
    gridRow: 16,
    gridColumn: 41,
  },
  {
    gridRow: 28,
    gridColumn: 11,
  },
  {
    gridRow: 30,
    gridColumn: 40,
  },
  {
    gridRow: 38,
    gridColumn: 18,
  },
  {
    gridRow: 39,
    gridColumn: 30,
  },
  {
    gridRow: 17,
    gridColumn: 21,
  },
  {
    gridRow: 25,
    gridColumn: 29,
  },
]
