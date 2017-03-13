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
    public class Bullet : MonoBehaviour {
        [SerializeField]
        float _health;
        public float damage, flyTime, knockback;

        public float health {
            get { return _health; }
            set {
                _health = value;
                if (_health <= 0) Destroy(gameObject);
            }
        }

        void Start() {
            health = _health;
            Destroy(gameObject, flyTime);
        }
   }
}