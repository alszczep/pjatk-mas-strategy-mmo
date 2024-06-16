<script setup lang="ts">
  import { useToast } from "vue-toast-notification"
  import type { TrainableUnitDTO } from "../../api/dtos/BuildingDetailsDTO"
  import ResourcesRow from "../common/ResourcesRow.vue"
  import { scheduleMilitaryUnitTrainingEndpoint } from "../../api/endpoints"
  import { defineModel } from "vue"
  import { router, routes } from "../../routes"

  const { troop, villageId } = defineProps<{
    troop: TrainableUnitDTO
    villageId: string
  }>()

  const amount = defineModel("amount", { type: Number })

  const $toast = useToast()

  const train = () => {
    if (!amount.value) {
      $toast.error("Amount is incorrect")
      return
    }
    scheduleMilitaryUnitTrainingEndpoint(
      villageId,
      troop.id,
      amount.value,
    ).then(() => {
      $toast.success("Troops training scheduled")
      router.push(routes.game.village.withParam(villageId))
    })
  }
</script>

<template>
  <div :key="troop.id" class="troop">
    <img :src="troop.iconUrl" class="troop-image" />
    <div class="resources-inner">
      <div>{{ troop.name }}</div>
      <ResourcesRow
        variant="tonal"
        class="resources"
        :values="troop.trainingCost"
      />
    </div>
    <v-text-field
      v-model="amount"
      class="input"
      hide-details="auto"
      label="Count"
      type="number"
      density="compact"
      min="1"
    ></v-text-field>
    <v-btn variant="tonal" @click="train">Train</v-btn>
  </div>
</template>

<style scoped>
  .resources-inner {
    display: flex;
    flex-direction: column;
    gap: 8px;
  }

  .resources {
    width: 450px;
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
