﻿//
//  Copyright (c) 2017  FederationOfCoders.org
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using UnityEngine;

namespace Deepio {
    public class PlayerHealth : ObjectWithHealth {
        [Space]
        public GameObject parent;
        public StatsHolder stats;

        float lastHealthRegen, lastMaxHealth;

        protected override void Start() {
            base.Start();

            health = maxHealth = lastMaxHealth = stats.maxHealth.value;
            healthRegen = lastHealthRegen = stats.healthRegen.value;
        }

        protected override void Update() {
            base.Update();

            if (health <= 0) Destroy(parent);

            float newHealthRegen = stats.healthRegen.value;
            if (newHealthRegen != lastHealthRegen)
                lastHealthRegen = healthRegen = stats.healthRegen.value;

            float newMaxHealth = stats.maxHealth.value;
            if (newMaxHealth != lastMaxHealth) {
                maxHealth = newMaxHealth;
                health = health * newMaxHealth / lastMaxHealth;
                lastMaxHealth = newMaxHealth;
            }
        }
    }
}
