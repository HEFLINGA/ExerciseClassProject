// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructureMapDependencyScope.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ExerciseProgram.WebUI.DependencyResolution {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ExerciseProgram.Domain.Abstract;
    using ExerciseProgram.Domain.Concrete;
    using ExerciseProgram.Domain.DAL;

    using Microsoft.Practices.ServiceLocation;
    using Moq;
    using StructureMap;
	
    /// <summary>
    /// The structure map dependency scope.
    /// </summary>
    public class StructureMapDependencyScope : ServiceLocatorImplBase {
        #region Constants and Fields

        private const string NestedContainerKey = "Nested.Container.Key";

        #endregion

        #region Constructors and Destructors

        public StructureMapDependencyScope(IContainer container) {
            if (container == null) {
                throw new ArgumentNullException("container");
            }
            Container = container;
        }

        #endregion

        private void AddBindings(IContainer container)
        {
            Mock<IExerciseRepository> mock = new Mock<IExerciseRepository>();
            mock.Setup(m => m.Exercises).Returns(new List<Exercise>
            {
                new Exercise{CategoryID = 1,
                    Name = "Bench press",
                    Description = "The bench press is an upper body strength training exercise that consists of pressing a weight upwards from a supine position.",
                    ExerciseMax = 225},
                new Exercise{CategoryID = 2,
                    Name = "Deadlift",
                    Description = "The deadlift is a weight training exercise in which a loaded barbell or bar is lifted off the ground to the level of the hips, then lowered to the ground.",
                    ExerciseMax = 275},
                new Exercise{CategoryID = 3,
                    Name = "Squat",
                    Description = "Movement begins from a standing position, lower your body towards the ground keeping good form, then back to the starting position. Bar is to be placed on your upper back and rear deltoids.",
                    ExerciseMax = 225},
                new Exercise{CategoryID = 4,
                    Name = "Military Press",
                    Description = "With bar starting at shoulder level, lift weight overhead until the elbows are fully locked out. As the weight clears the head, the lifter leans forward slightly, or comes directly under, in order to keep balance. As the weight is lowered back to racking position and clears the head again, the lifter leans slightly back.",
                    ExerciseMax = 155}
            });
            container.Inject<IExerciseRepository>(mock.Object);
        }

        #region Public Properties

        public IContainer Container { get; set; }

        public IContainer CurrentNestedContainer {
            get {
                return (IContainer)HttpContext.Items[NestedContainerKey];
            }
            set {
                HttpContext.Items[NestedContainerKey] = value;
            }
        }

        #endregion

        #region Properties

        private HttpContextBase HttpContext {
            get {
                var ctx = Container.TryGetInstance<HttpContextBase>();
                return ctx ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            }
        }

        #endregion

        #region Public Methods and Operators

        public void CreateNestedContainer() {
            if (CurrentNestedContainer != null) {
                return;
            }
            CurrentNestedContainer = Container.GetNestedContainer();
        }

        public void Dispose() {
            DisposeNestedContainer();
            Container.Dispose();
        }

        public void DisposeNestedContainer() {
            if (CurrentNestedContainer != null) {
                CurrentNestedContainer.Dispose();
				CurrentNestedContainer = null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return DoGetAllInstances(serviceType);
        }

        #endregion

        #region Methods

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType) {
            return (CurrentNestedContainer ?? Container).GetAllInstances(serviceType).Cast<object>();
        }

        protected override object DoGetInstance(Type serviceType, string key) {
            IContainer container = (CurrentNestedContainer ?? Container);

            if (string.IsNullOrEmpty(key)) {
                return serviceType.IsAbstract || serviceType.IsInterface
                    ? container.TryGetInstance(serviceType)
                    : container.GetInstance(serviceType);
            }

            return container.GetInstance(serviceType, key);
        }

        #endregion
    }
}
