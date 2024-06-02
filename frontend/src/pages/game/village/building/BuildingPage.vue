<script setup lang="ts">
  import { useRoute } from "vue-router"
  import { routes } from "../../../../routes"
  import type {
    BuildableBuildingDTO,
    BuildingDetailsDTO,
  } from "../../../../api/dtos"
  import ResourcesRow from "../../../../components/common/ResourcesRow.vue"
  import BuildableBuildingsList from "../../../../components/building/BuildableBuildingsList.vue"

  const route = useRoute()
  const villageId = route.params[routes.game.village.param] as string
  const placeInVillage = route.params[
    routes.game.village.building.param
  ] as string

  const buildingDetails: BuildingDetailsDTO = {
    id: "1",
    name: "Mine",
    level: 1,
    imageUrl:
      "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
    place: 1,
    upgradeCost: {
      wood: 200,
      iron: 80,
      wheat: 100,
      gold: 20,
    },
    production: {
      wood: 0,
      iron: 50,
      wheat: 0,
      gold: 20,
    },
    trainableTroops: undefined,
  }
  // const buildingDetails: BuildingDetailsDTO = {
  //   id: "1",
  //   name: "Barracks",
  //   level: 2,
  //   imageUrl:
  //     "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
  //   place: 2,
  //   upgradeCost: {
  //     wood: 120,
  //     iron: 200,
  //     wheat: 50,
  //     gold: 150,
  //   },
  //   trainableTroops: [
  //     {
  //       id: "1",
  //       imageUrl:
  //         "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
  //         minBarracksLevel: 1,
  //         name: "Swordsman",
  //         unitCost: {
  //           wood: 0,
  //           iron: 50,
  //           wheat: 20,
  //           gold: 20,
  //         },
  //     }
  //   ],
  // }
  const buildableBuildings: BuildableBuildingDTO[] = [
    {
      id: "1",
      name: "Mine",
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      cost: {
        wood: 200,
        iron: 80,
        wheat: 100,
        gold: 20,
      },
    },
    {
      id: "2",
      name: "Barracks",
      imageUrl:
        "https://opengameart.org/sites/default/files/styles/medium/public/blacksmith.svg_.png",
      cost: {
        wood: 120,
        iron: 200,
        wheat: 50,
        gold: 150,
      },
    },
  ]
</script>

<template>
  <div class="page-wrapper">
    <ResourcesRow
      :values="{ wood: 100, iron: 200, wheat: 300, gold: 400 }"
      class="resources"
    />
    <BuildableBuildingsList
      :buildings="buildableBuildings"
      :village-id="villageId"
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
    margin-bottom: 8px;
  }
</style>
