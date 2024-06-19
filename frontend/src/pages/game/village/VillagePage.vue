<script setup lang="ts">
  import { ref } from "vue"
  import {
    updateBuildingsQueueEndpoint,
    updateMilitaryUnitsQueueEndpoint,
    villageByIdEndpoint,
  } from "../../../api/endpoints"
  import BuildingsGrid from "../../../components/village/BuildingsGrid.vue"
  import OperationQueue from "../../../components/village/OperationQueue.vue"
  import { useRoute } from "vue-router"
  import { routes } from "../../../routes"
  import ResourcesRow from "../../../components/common/ResourcesRow.vue"
  import WholePageLoader from "../../../components/common/WholePageLoader.vue"
  import TroopsList from "../../../components/village/TroopsList.vue"
  import type { VillageDetailsDTO } from "../../../api/dtos/VillageDetailsDTO"
  import { useInterval } from "@vueuse/core"

  const route = useRoute()
  const villageId = route.params[routes.game.village.param] as string

  const village = ref<VillageDetailsDTO>()
  // HACK: when an object, that is an array element, has a field updated, it won't trigger updates
  const updateCount = ref(0)

  async function fetchVillage() {
    if (villageId === undefined) {
      return
    }

    village.value = await villageByIdEndpoint(villageId)
    updateCount.value++
  }
  fetchVillage()
  useInterval(60000, {
    callback: fetchVillage,
  })

  const updateBuildingsQueue = async () => {
    if (villageId === undefined) {
      return
    }

    await updateBuildingsQueueEndpoint(villageId)
    fetchVillage()
  }

  const updateMilitaryUnitsQueue = async () => {
    if (villageId === undefined) {
      return
    }

    await updateMilitaryUnitsQueueEndpoint(villageId)
    fetchVillage()
  }
</script>

<template>
  <WholePageLoader v-if="!village" />
  <div class="page-wrapper" :key="updateCount" v-else>
    <ResourcesRow :values="village.availableResources" class="resources" />
    <div class="buildings-and-troops">
      <BuildingsGrid
        :buildings="village.buildings.map((b) => b)"
        :village-id="villageId"
        class="buildings"
      />
      <TroopsList
        :troops="
          village.militaryUnits.map((unit) => ({
            name: unit.name,
            imageUrl: unit.iconUrl as string, // TODO: placeholder
            count: unit.amount,
          }))
        "
      />
    </div>
    <OperationQueue
      title="Buildings queue"
      info-column-title="Upgrade to level"
      :items="
        village.buildingsQueue.map((building) => ({
          name: building.buildingName,
          finishTimestamp: new Date(`${building.endTime}Z`).getTime(),
          infoColumn: building.toLevel.toString(),
        }))
      "
      :on-finish="updateBuildingsQueue"
    />
    <OperationQueue
      title="Troops training queue"
      info-column-title="Number of troops"
      :items="
        village.militaryUnitsQueue.map((unit) => ({
          name: unit.militaryUnitName,
          finishTimestamp: new Date(`${unit.endTime}Z`).getTime(),
          infoColumn: unit.amount.toString(),
        }))
      "
      class="troops-training-queue"
      :on-finish="updateMilitaryUnitsQueue"
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

  .buildings-and-troops {
    width: 100%;
    display: grid;
    grid-template-columns: 1fr 400px;
  }

  .buildings {
    margin: 0 auto;
  }

  .troops-training-queue {
    margin-top: 16px;
  }
</style>
