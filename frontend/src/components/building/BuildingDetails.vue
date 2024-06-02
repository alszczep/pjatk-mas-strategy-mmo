<script setup lang="ts">
  import type { BuildingDetailsDTO } from "../../api/dtos"
  import ResourcesRow from "../common/ResourcesRow.vue"

  const { building, villageId } = defineProps<{
    building: BuildingDetailsDTO
    villageId: string
  }>()

  const upgrade = () => {
    alert("TODO")
  }

  const train = () => {
    alert("TODO")
  }
</script>

<template>
  <v-card class="wrapper">
    <v-card-title
      >{{ building.name }} - level {{ building.level }}</v-card-title
    >
    <v-card-text class="text">
      <div class="top">
        <img :src="building.imageUrl" class="building-image" />
        <div class="top-desc">
          <div v-if="building.production" class="resources-wrapper">
            <div class="resources-inner">
              <div>Current production per minute</div>
              <ResourcesRow
                variant="tonal"
                class="resources"
                :values="building.production"
              />
            </div>
          </div>
          <div class="resources-wrapper">
            <div class="resources-inner">
              <div>Cost of upgrade to {{ building.level + 1 }} level</div>
              <ResourcesRow
                variant="tonal"
                class="resources"
                :values="building.upgradeCost"
              />
            </div>
            <v-btn variant="tonal" class="upgrade-button" @click="upgrade">
              Upgrade
            </v-btn>
          </div>
        </div>
      </div>
      <div v-if="building.trainableTroops" class="troops">
        <h3>Trainable troops</h3>
        <div
          v-for="troop in building.trainableTroops"
          :key="troop.id"
          class="troop"
        >
          <img :src="troop.imageUrl" class="troop-image" />
          <div class="resources-inner">
            <div>{{ troop.name }}</div>
            <ResourcesRow
              variant="tonal"
              class="resources"
              :values="troop.unitCost"
            />
          </div>
          <v-text-field
            class="input"
            hide-details="auto"
            label="Count"
            type="number"
            density="compact"
            min="1"
          ></v-text-field>
          <v-btn variant="tonal" @click="train">Train</v-btn>
        </div>
      </div>
    </v-card-text>
  </v-card>
</template>

<style scoped>
  .wrapper {
    width: 100%;
  }

  .text {
    display: flex;
    flex-direction: column;
  }

  .top {
    display: flex;
    gap: 24px;
  }

  .top-desc {
    display: flex;
    flex-direction: column;
    gap: 24px;
    width: 100%;
  }

  .resources-wrapper {
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: 100%;
  }

  .resources-inner {
    display: flex;
    flex-direction: column;
    gap: 8px;
  }

  .upgrade-button {
    align-self: flex-end;
  }

  .building-image {
    width: 192px;
    height: 192px;
  }

  .resources {
    width: 450px;
  }

  .troops {
    display: flex;
    flex-direction: column;
    gap: 16px;
    margin-top: 24px;
  }

  .troop {
    display: flex;
    gap: 12px;
    align-items: center;
  }

  .troop-image {
    width: 40px;
    height: 40px;
  }

  .input {
    max-width: 120px;
  }
</style>
