<script setup lang="ts">
  import { ref } from "vue"
  import { ownerVillageEndpoint } from "../../../api/endpoints"
  import Building from "../../../components/village/Building.vue"

  const villageName = ref<string>()

  async function fetchOwnersVillage() {
    villageName.value = (await ownerVillageEndpoint()).name
  }
  fetchOwnersVillage()

  const buildings = [
    {
      place: 0,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
    {
      place: 1,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
    {
      place: 2,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
    {
      place: 3,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
    {
      place: 4,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
    {
      place: 5,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
    {
      place: 6,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
    {
      place: 7,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
    {
      place: 8,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
    {
      place: 9,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
  ]

  const buildingGridHeight = 6
  const buildingGridWidth = 6

  const buildingPlaceToPosition = [
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

  const appendSizeToGridPosition = (position: {
    gridRow: number
    gridColumn: number
  }) => {
    const heightHalf = Math.floor(buildingGridHeight / 2)
    const widthHalf = Math.floor(buildingGridWidth / 2)
    return {
      gridRow: `${position.gridRow - heightHalf} / ${position.gridRow + heightHalf}`,
      gridColumn: `${position.gridColumn - widthHalf} / ${position.gridColumn + widthHalf}`,
    }
  }

  const buildingsWithPosition = buildings.map((building, index) => {
    return {
      ...building,
      ...appendSizeToGridPosition(buildingPlaceToPosition[index]),
    }
  })
  console.log(buildingsWithPosition)
</script>

<template>
  <div class="page-wrapper">
    <div class="buildings-grid">
      <div
        v-for="building in buildingsWithPosition"
        :key="building.place"
        class="building-wrapper"
        :style="{ gridRow: building.gridRow, gridColumn: building.gridColumn }"
      >
        <Building :image-url="building.imageUrl" :level="building.level" />
      </div>
    </div>

    <!-- <h1>{{ villageName }}</h1> -->
  </div>
</template>

<style scoped>
  .page-wrapper {
    display: flex;
    justify-content: center;
  }

  .buildings-grid {
    display: grid;
    grid-template: repeat(50, 1fr) / repeat(50, 1fr);

    width: 800px;
    height: 600px;
  }

  /* .building-wrapper {
    width: 80px;
    height: 100px;
  } */
</style>
