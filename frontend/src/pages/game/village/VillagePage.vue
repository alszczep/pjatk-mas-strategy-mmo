<script setup lang="ts">
  import { ref } from "vue"
  import { ownerVillageEndpoint } from "../../../api/endpoints"
  import type { BuildingSummaryDTO } from "../../../api/dtos"
  import BuildingsGrid from "../../../components/village/BuildingsGrid.vue"

  const villageName = ref<string>()

  async function fetchOwnersVillage() {
    villageName.value = (await ownerVillageEndpoint()).name
  }
  fetchOwnersVillage()

  // TODO: get from backend
  const buildings: BuildingSummaryDTO[] = [
    {
      place: 0,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
    {
      place: 1,
    },
    {
      place: 2,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 1,
    },
    {
      place: 3,
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
      level: 20,
    },
    {
      place: 9,
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      level: 15,
    },
  ]
</script>

<template>
  <div class="page-wrapper">
    <BuildingsGrid :buildings="buildings" />

    <!-- <h1>{{ villageName }}</h1> -->
  </div>
</template>

<style scoped>
  .page-wrapper {
    display: flex;
    justify-content: center;
  }
</style>
