using Microsoft.Xrm.Sdk;
using SRC.Library.Entities.CustomEntities;
using SRC.Plugins.CrmPlugin.Entities;
using SRC.Plugins.CrmPlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Plugins.CrmPlugin
{
    public abstract class BasePluginTask : IBasePluginTask
    {
        private const string ENTITY_ATTRIBUTE_NAME = "Target";
        private const string PRE_IMAGE_ATTRIBUTE_NAME = "PreImage";
        private const string POST_IMAGE_ATTRIBUTE_NAME = "PostImage";
        private const string ENTITY_MONIKER = "EntityMoniker";
        private const string STATUS = "Status";
        private const string STATE = "State";
        private const string PLUGIN_ENTITY_ID_PROPERTY_NAME = "Id";

        protected IPluginExecutionContext _context;
        protected PluginOperation _pluginOperation;
        protected EntityContainer _entityContainer;


        public BasePluginTask()
        {

        }

        protected Entity GetEntity()
        {
            if (_context.InputParameters.Contains(ENTITY_ATTRIBUTE_NAME))
            {
                return (Entity)_context.InputParameters[ENTITY_ATTRIBUTE_NAME];
            }

            return null;
        }

        protected Entity GetPreImage()
        {
            if (_context.PreEntityImages.Contains(PRE_IMAGE_ATTRIBUTE_NAME))
            {
                return (Entity)_context.PreEntityImages[PRE_IMAGE_ATTRIBUTE_NAME];
            }

            return null;
        }

        protected Entity GetPostImage()
        {
            if (_context.PostEntityImages.Contains(POST_IMAGE_ATTRIBUTE_NAME))
            {
                return (Entity)_context.PostEntityImages[POST_IMAGE_ATTRIBUTE_NAME];
            }

            return null;
        }

        protected SetStateEntity GetSetStateEntity()
        {
            if (_context.InputParameters.Contains(ENTITY_MONIKER)
                && _context.InputParameters.Contains(STATUS)
                && _context.InputParameters.Contains(STATE))
            {
                return new SetStateEntity()
                {
                    EntityMoniker = (EntityReference)_context.InputParameters[ENTITY_MONIKER],
                    Status = (OptionSetValue)_context.InputParameters[STATUS],
                    State = (OptionSetValue)_context.InputParameters[STATE]
                };

            }

            return null;
        }

        protected EntityContainer GetEntityContainer()
        {
            var entityContainer = new EntityContainer()
            {
                Input = this.GetEntity(),
                PreImage = this.GetPreImage(),
                PostImage = this.GetPostImage(),
                UserId = this._context.UserId,
                SetStateInput = this.GetSetStateEntity()
            };

            if (entityContainer.Merged != null && entityContainer.Merged.Id != Guid.Empty)
            {
                entityContainer.EntityId = entityContainer.Merged.Id;
            }

            return entityContainer;
        }

        protected TObject GetAttributeValueFromGivenEntities<TObject>(string attributeName, params Entity[] entities)
        {
            foreach (Entity entity in entities)
            {
                TObject value = entity.GetAttributeValue<TObject>(attributeName);

                if (value != null)
                {
                    return (TObject)entity[attributeName];
                }
            }

            return default(TObject);
        }

        protected bool IsAttributeValueChanged<TObject>(string attributeName, Entity inputEntity, Entity imageEntity)
        {
            TObject initialValue = default(TObject);
            TObject newValue = default(TObject);

            if (inputEntity.Contains(attributeName))
            {
                newValue = inputEntity.GetAttributeValue<TObject>(attributeName);

                if (imageEntity.Contains(attributeName) && imageEntity[attributeName] != null)
                {
                    initialValue = (TObject)imageEntity[attributeName];
                }

                if (!EqualityComparer<TObject>.Default.Equals(initialValue, newValue))
                {
                    return true;
                }
            }

            return false;
        }

        protected bool IsAttributeSetToNull(string attributeName, Entity entity)
        {
            return (entity.Contains(attributeName) && entity[attributeName] == null);
        }

        public void Process(IPluginExecutionContext context, PluginOperation pluginOperation)
        {
            _context = context;
            _pluginOperation = pluginOperation;
            _entityContainer = GetEntityContainer();

            try
            {
                switch (pluginOperation)
                {
                    case PluginOperation.PRE_CREATE:
                        PreCreate();
                        break;
                    case PluginOperation.POST_CREATE:
                        PostCreate();
                        break;
                    case PluginOperation.PRE_UPDATE:
                        PreUpdate();
                        break;
                    case PluginOperation.POST_UPDATE:
                        PostUpdate();
                        break;
                    case PluginOperation.PRE_DELETE:
                        PreDelete();
                        break;
                    case PluginOperation.POST_DELETE:
                        PostDelete();
                        break;
                    case PluginOperation.SET_STATE:
                        SetState();
                        break;
                    default:
                        break;
                }
            }
            catch (CustomException ex)
            {
                if (string.IsNullOrWhiteSpace(ex.ContextIdentifier))
                {
                    string contextIdentifier = (_entityContainer.EntityId ?? Guid.Empty).ToString();
                    ex.ContextIdentifier = contextIdentifier;
                }

                throw ex;
            }
            catch (Exception ex)
            {
                string contextIdentifier = (_entityContainer.EntityId ?? Guid.Empty).ToString();
                string logKey = ex.GetType().Name;

                throw new CustomException(ex.Message, logKey, contextIdentifier);
            }
        }

        protected abstract void PreCreate();
        protected abstract void PostCreate();
        protected abstract void PreUpdate();
        protected abstract void PostUpdate();
        protected abstract void PreDelete();
        protected abstract void PostDelete();
        protected abstract void SetState();

    }
}
