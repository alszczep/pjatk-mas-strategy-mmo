<script setup lang="ts">
  import { ref } from "vue"
  import {
    ownerVillageEndpoint,
    villageByIdEndpoint,
  } from "../../../api/endpoints"
  import type { BuildingSummaryDTO } from "../../../api/dtos"
  import BuildingsGrid from "../../../components/village/BuildingsGrid.vue"
  import OperationQueue from "../../../components/village/OperationQueue.vue"

  import { useRoute } from "vue-router"
  import { routes } from "../../../routes"
  import ResourcesRow from "../../../components/common/ResourcesRow.vue"

  const route = useRoute()
  const villageId = route.params[routes.game.village.param] as string

  const villageName = ref<string>()

  async function fetchOwnersVillage() {
    if (villageId === undefined) {
      return
    }

    if (villageId === routes.game.village.paramDefault) {
      villageName.value = (await ownerVillageEndpoint()).name
      return
    }

    villageName.value = (await villageByIdEndpoint(villageId)).name
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

  // TODO: get from backend
  const buildingsQueue = [
    {
      name: "Koszary",
      finishTimestamp: 1717258788000,
      infoColumn: "4",
    },
    {
      name: "Chata drwala",
      finishTimestamp: 1717264108000,
      infoColumn: "7",
    },
    {
      name: "Kopalnia",
      finishTimestamp: 1717343308000,
      infoColumn: "1",
    },
  ]

  // TODO: get from backend
  const trainingQueue: any[] = []
</script>

<template>
  <div class="page-wrapper">
    <!-- TODO: get from backend -->
    <div class="resources">
      <ResourcesRow :values="{ wood: 100, iron: 200, wheat: 300, gold: 400 }" />
    </div>
    <BuildingsGrid :buildings="buildings" :village-id="villageId" />
    <OperationQueue
      title="Buildings queue"
      info-column-title="Upgrade to level"
      :items="buildingsQueue"
    />
    <OperationQueue
      title="Troops training queue"
      info-column-title="Number of troops"
      :items="trainingQueue"
    />
  </div>
</template>

<style scoped>
  .page-wrapper {
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .resources {
    width: 100%;
    padding: 4px 8px 16px;
  }
</style>
